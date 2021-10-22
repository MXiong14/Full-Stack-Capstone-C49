using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KicksKollector.Models;
using KicksKollector.Utils;
using Microsoft.Extensions.Configuration;

namespace KicksKollector.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(IConfiguration configuration) : base(configuration) { }

        public List<Post> GetAll()
        {
            using var conn = Connection;
            conn.Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                    SELECT p.Id, p.Name, p.Size, p.StyleCode, p.Quantity, p.PurchasePrice, p.SoldPrice, p.BrandId, p.UserProfileId,
	                       up.Email, up.FirstName, up.LastName,
	                       b.[Name]
                    FROM Post p
                    LEFT JOIN UserProfile up ON p.UserProfileId = up.Id
                    LEFT JOIN Brand b ON p.BrandId = b.Id";

            List<Post> posts = new List<Post>();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var post = new Post()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name"),
                    Size = DbUtils.GetInt(reader, "Size"),
                    StyleCode = DbUtils.GetString(reader, "StyleCode"),
                    PurchasePrice = DbUtils.GetInt(reader, "PurchasePrice"),
                    SoldPrice = DbUtils.GetInt(reader, "SoldPrice"),
                    BrandId = DbUtils.GetInt(reader, "BrandId"),
                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                };

                post.UserProfile = new UserProfile()
                {
                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                    Email = DbUtils.GetString(reader, "Email"),
                    FirstName = DbUtils.GetString(reader, "FirstName"),
                    LastName = DbUtils.GetString(reader, "LastName"),
                   
                };

                post.Brand = new Brand()
                {
                    Id = DbUtils.GetInt(reader, "BrandId"),
                    Name = DbUtils.GetString(reader, "Name")
                };

                posts.Add(post);
            }

            return posts;
        }

        public List<Post> GetUserPosts(int id)
        {
            using var conn = Connection;
            conn.Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                    SELECT p.Id, p.Name, p.Size, p.StyleCode, p.Quantity, p.PurchasePrice, p.SoldPrice, p.BrandId, p.UserProfileId,
	                       up.Email, up.FirstName, up.LastName,
	                       b.[Name]
                    FROM Post p
                    LEFT JOIN UserProfile up ON p.UserProfileId = up.Id
                    LEFT JOIN Brand b ON p.BrandId = b.Id
                    WHERE up.id = @Id";

            DbUtils.AddParameter(cmd, "@Id", id);

            List<Post> posts = new List<Post>();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var post = new Post()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name"),
                    Size = DbUtils.GetInt(reader, "Size"),
                    StyleCode = DbUtils.GetString(reader, "StyleCode"),
                    PurchasePrice = DbUtils.GetInt(reader, "PurchasePrice"),
                    SoldPrice = DbUtils.GetInt(reader, "SoldPrice"),
                    BrandId = DbUtils.GetInt(reader, "BrandId"),
                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                };

                post.UserProfile = new UserProfile()
                {
                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                    Email = DbUtils.GetString(reader, "Email"),
                    FirstName = DbUtils.GetString(reader, "FirstName"),
                    LastName = DbUtils.GetString(reader, "LastName"),

                };

                post.Brand = new Brand()
                {
                    Id = DbUtils.GetInt(reader, "BrandId"),
                    Name = DbUtils.GetString(reader, "Name")
                };

                posts.Add(post);
            }

            return posts;
        }

        public Post GetPostById(int id)
        {
            using var conn = Connection;
            conn.Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                    SELECT p.Id, p.Name, p.Size, p.StyleCode, p.Quantity, p.PurchasePrice, p.SoldPrice, p.BrandId, p.UserProfileId,
	                       up.Email, up.FirstName, up.LastName,
	                       b.[Name]
                    FROM Post p
                    LEFT JOIN UserProfile up ON p.UserProfileId = up.Id
                    LEFT JOIN Brand b ON p.BrandId = b.Id
                    WHERE p.id = @Id";

            DbUtils.AddParameter(cmd, "@Id", id);


            using var reader = cmd.ExecuteReader();
            Post post = null;

            if (reader.Read())
            {
                 post = new Post()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name"),
                    Size = DbUtils.GetInt(reader, "Size"),
                    StyleCode = DbUtils.GetString(reader, "StyleCode"),
                    PurchasePrice = DbUtils.GetInt(reader, "PurchasePrice"),
                    SoldPrice = DbUtils.GetInt(reader, "SoldPrice"),
                    BrandId = DbUtils.GetInt(reader, "BrandId"),
                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                };

                post.UserProfile = new UserProfile()
                {
                    Id = DbUtils.GetInt(reader, "UserProfileId"),
                    Email = DbUtils.GetString(reader, "Email"),
                    FirstName = DbUtils.GetString(reader, "FirstName"),
                    LastName = DbUtils.GetString(reader, "LastName"),

                };

                post.Brand = new Brand()
                {
                    Id = DbUtils.GetInt(reader, "BrandId"),
                    Name = DbUtils.GetString(reader, "Name")
                };

            }
            return post;
        }
    }
}

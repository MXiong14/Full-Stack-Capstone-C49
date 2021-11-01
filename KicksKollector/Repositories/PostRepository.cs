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
	                       b.SubBrand
                    FROM Post p
                    LEFT JOIN UserProfile up ON p.UserProfileId = up.Id
                    LEFT JOIN Brand b ON p.BrandId = b.Id
                    ORDER BY p.Id DESC";

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
                    Quantity = DbUtils.GetInt(reader, "Quantity"),
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
                    SubBrand = DbUtils.GetString(reader, "SubBrand")
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
	                       b.SubBrand
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
                    Quantity = DbUtils.GetInt(reader, "Quantity"),
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
                    SubBrand = DbUtils.GetString(reader, "SubBrand")
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
	                       b.Id, b.SubBrand
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
                    Quantity = DbUtils.GetInt(reader, "Quantity"),
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
                    SubBrand = DbUtils.GetString(reader, "SubBrand")
                };

            }
            return post;
        }

        public void AddPost(Post post)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Post (
                                        Name, Size, StyleCode, Quantity,
                                        PurchasePrice, SoldPrice, UserProfileId, BrandId)
                                        OUTPUT INSERTED.ID
                                        VALUES(@name, @size, @styleCode, @quantity, @purchasePrice, @soldPrice, @userProfileId, @brandId);";
                    DbUtils.AddParameter(cmd, "@name", post.Name);
                    DbUtils.AddParameter(cmd, "@size", post.Size);
                    DbUtils.AddParameter(cmd, "@styleCode", post.StyleCode);
                    DbUtils.AddParameter(cmd, "@quantity", post.Quantity);
                    DbUtils.AddParameter(cmd, "@purchasePrice", post.PurchasePrice);
                    DbUtils.AddParameter(cmd, "@soldPrice", post.SoldPrice);
                    DbUtils.AddParameter(cmd, "@userProfileId", post.UserProfileId);
                    DbUtils.AddParameter(cmd, "@brandId", post.BrandId);

                    post.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdatePost(Post post)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      UPDATE Post SET 
                      Name = @Name,
                      Size = @Size,
                      StyleCode = @StyleCode, 
                      Quantity = @Quantity,
                      PurchasePrice = @PurchasePrice,
                      SoldPrice = @SoldPrice,
                      BrandId = @BrandId,
                      UserProfileId = @UserProfileId
                      WHERE Id = @id";

                    DbUtils.AddParameter(cmd, "@Name", post.Name);
                    DbUtils.AddParameter(cmd, "@Size", post.Size);
                    DbUtils.AddParameter(cmd, "@StyleCode", post.StyleCode);
                    DbUtils.AddParameter(cmd, "@Quantity", post.Quantity);
                    DbUtils.AddParameter(cmd, "@PurchasePrice", post.PurchasePrice);
                    DbUtils.AddParameter(cmd, "@SoldPrice", post.SoldPrice);
                    DbUtils.AddParameter(cmd, "@BrandId", post.BrandId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", post.UserProfileId);
                    DbUtils.AddParameter(cmd, "@id", post.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeletePost(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        DELETE FROM POST
                                        WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

  
    }
}

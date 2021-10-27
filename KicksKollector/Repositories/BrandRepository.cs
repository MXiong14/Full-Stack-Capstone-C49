using KicksKollector.Models;
using KicksKollector.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KicksKollector.Repositories
{
    public class BrandRepository : BaseRepository, IBrandRepository
    {
        public BrandRepository(IConfiguration configuration) : base(configuration) { }

        public List<Brand> GetAll()
        {
            using var conn = Connection;
            conn.Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                    SELECT Id, [Name]
                    FROM Brand
                    ORDER BY [Name]";

            using var reader = cmd.ExecuteReader();

            var brands = new List<Brand>();

            while (reader.Read())
            {
                var brand = new Brand()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name")
                };
                brands.Add(brand);
            }
            return brands;
        }
        public Brand GetBrandById(int id)
        {
            using var conn = Connection;
            conn.Open();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT Id, Name
                                  FROM Brand
                                  WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            Brand brand = null;

            if (reader.Read())
            {
                brand = new Brand
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Name = DbUtils.GetString(reader, "Name"),
                };

            }
            reader.Close();
            return brand;



        }
    }
}

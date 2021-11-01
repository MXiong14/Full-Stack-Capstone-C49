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
                    SELECT Id, SubBrand
                    FROM Brand
                    ORDER BY SubBrand";

            using var reader = cmd.ExecuteReader();

            var brands = new List<Brand>();

            while (reader.Read())
            {
                var brand = new Brand()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    SubBrand = DbUtils.GetString(reader, "SubBrand")
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

            cmd.CommandText = @"SELECT Id, SubBrand
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
                    SubBrand = DbUtils.GetString(reader, "SubBrand"),
                };

            }
            reader.Close();
            return brand;
        }

        public void Add(Brand brand)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Brand (SubBrand)
                                        OUTPUT INSERTED.ID
                                        VALUES (@subbrand)";

                    DbUtils.AddParameter(cmd, "@name", brand.SubBrand);

                    brand.Id = (int)cmd.ExecuteScalar();

                }
            }
        }

        public void Edit(Brand brand)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Brand
                                        SET SubBrand = @subbrand
                                        WHERE Id = @id";

                    DbUtils.AddParameter(cmd, "@subbrand", brand.SubBrand);
                    DbUtils.AddParameter(cmd, "@id", brand.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int brandId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Brand
                                        WHERE Id = @id";

                    DbUtils.AddParameter(cmd, "@id", brandId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

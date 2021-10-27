using System.Collections.Generic;
using KicksKollector.Models;

namespace KicksKollector.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand GetBrandById(int id);
        void Add(Brand brand);
        void Edit(Brand brand);
        void Delete(int brandId);
    }
}
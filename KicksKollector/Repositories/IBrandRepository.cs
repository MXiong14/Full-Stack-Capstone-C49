using System.Collections.Generic;
using KicksKollector.Models;

namespace KicksKollector.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand GetBrandById(int id);
    }
}
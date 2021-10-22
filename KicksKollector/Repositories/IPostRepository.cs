using KicksKollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KicksKollector.Repositories
{
    public interface IPostRepository
    {

        List<Post> GetAll();
        List<Post> GetUserPosts(int id);
        Post GetPostById(int id);


    }
}

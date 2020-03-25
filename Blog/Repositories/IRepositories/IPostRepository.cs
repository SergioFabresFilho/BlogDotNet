using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repositories.IRepositories
{
    public interface IPostRepository
    {
        ICollection<Post> GetPosts();
        Post GetPost(int id);
        bool CreatePost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(Post post);
        bool Save();
    }
}

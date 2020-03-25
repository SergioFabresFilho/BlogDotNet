using Blog.Data;
using Blog.Models;
using Blog.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;

        public PostRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreatePost(Post post)
        {
            _db.Posts.Add(post);
            return Save();
        }

        public bool DeletePost(Post post)
        {
            _db.Posts.Remove(post);
            return Save();
        }

        public Post GetPost(int id)
        {
            return _db.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Post> GetPosts()
        {
            return _db.Posts.Include(p => p.Comments).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdatePost(Post post)
        {
            _db.Posts.Update(post);
            return Save();
        }
    }
}

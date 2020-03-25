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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateComment(Comment comment)
        {
            _db.Comments.Add(comment);
            return Save();
        }

        public bool DeleteComment(Comment comment)
        {
            _db.Comments.Remove(comment);
            return Save();
        }

        public Comment GetComment(int id)
        {
            return _db.Comments.Include(c => c.Post).FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Comment> GetCommentsFromPost(int postId)
        {
            return _db.Comments.Include(c => c.Post).Where(c => c.PostId == postId).ToList();
        }

        public ICollection<Comment> GetComments()
        {
            return _db.Comments.Include(c => c.Post).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateComment(Comment comment)
        {
            _db.Comments.Update(comment);
            return Save();
        }
    }
}

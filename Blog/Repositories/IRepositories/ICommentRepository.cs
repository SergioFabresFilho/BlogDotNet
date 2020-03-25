using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repositories.IRepositories
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetCommentsFromPost(int postId);
        ICollection<Comment> GetComments();
        Comment GetComment(int id);
        bool CreateComment(Comment comment);
        bool UpdateComment(Comment comment);
        bool DeleteComment(Comment comment);
        bool Save();
    }
}

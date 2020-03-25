using Blog.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.IServices
{
    public interface ICommentService
    {
        ICollection<CommentDto> GetCommentsFromPost(int postId);
        ICollection<CommentDto> GetComments();
        CommentDto GetComment(int id);
        bool CreateComment(CommentDto commentDto);
        bool UpdateComment(CommentDto commentDto);
        bool DeleteComment(CommentDto commentDto);
    }
}

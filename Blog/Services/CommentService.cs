using AutoMapper;
using Blog.Models;
using Blog.Models.Dtos;
using Blog.Repositories.IRepositories;
using Blog.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICollection<CommentDto> GetCommentsFromPost(int postId)
        {
            var comments = _repository.GetCommentsFromPost(postId);
            return _mapper.Map<ICollection<Comment>, ICollection<CommentDto>>(comments);
        }

        public ICollection<CommentDto> GetComments()
        {
            var comments = _repository.GetComments();
            return _mapper.Map<ICollection<Comment>, ICollection<CommentDto>>(comments);
        }

        public CommentDto GetComment(int id)
        {
            var comment = _repository.GetComment(id);
            return _mapper.Map<CommentDto>(comment);
        }

        public bool CreateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            return _repository.CreateComment(comment);
        }

        public bool UpdateComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            return _repository.UpdateComment(comment);
        }

        public bool DeleteComment(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            return _repository.DeleteComment(comment);
        }
    }
}

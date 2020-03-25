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
    public class PostService : IPostService
    {
        private IPostRepository _repository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICollection<PostDto> GetPosts()
        {
            var posts = _repository.GetPosts();
            return _mapper.Map<ICollection<Post>, ICollection<PostDto>>(posts);
        }

        public PostDto GetPost(int id)
        {
            var post = _repository.GetPost(id);
            return _mapper.Map<PostDto>(post);
        }

        public bool CreatePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            return _repository.CreatePost(post);
        }

        public bool UpdatePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            return _repository.UpdatePost(post);
        }

        public bool DeletePost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            return _repository.DeletePost(post);
        }
    }
}

using Blog.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.IServices
{
    public interface IPostService
    {
        ICollection<PostDto> GetPosts();
        PostDto GetPost(int id);
        bool CreatePost(PostDto postDto);
        bool UpdatePost(PostDto postDto);
        bool DeletePost(PostDto postDto);
    }
}

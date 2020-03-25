using AutoMapper;
using Blog.Models;
using Blog.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.AutoMapper
{
    public class BlogMappings : Profile
    {
        public BlogMappings()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public PostDto Post { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Dtos;
using Blog.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _service.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _service.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] PostDto postDto)
        {
            if (postDto == null)
            {
                return BadRequest();
            }

            if (!_service.CreatePost(postDto))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the post {postDto.Title}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostDto postDto)
        {
            if (postDto == null)
            {
                return BadRequest();
            }

            if (!_service.UpdatePost(postDto))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the post {postDto.Title}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var postDto = _service.GetPost(id);

            if (postDto == null)
            {
                return NotFound();
            }

            if (!_service.DeletePost(postDto))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting post {postDto.Title}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }
    }
}
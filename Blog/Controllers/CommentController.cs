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
    [Route("api/post/{postId}/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetComments(int postId)
        {
            var comments = _service.GetCommentsFromPost(postId);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _service.GetComment(id);
            
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest();
            }

            if (!_service.CreateComment(commentDto))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the comment {commentDto.Text}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] CommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest();
            }

            if (!_service.UpdateComment(commentDto))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the comment {commentDto.Text}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var commentDto = _service.GetComment(id);

            if (commentDto == null)
            {
                return NotFound();
            }

            if (!_service.DeleteComment(commentDto))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting comment {commentDto.Text}");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }

            return NoContent();
        }
    }
}
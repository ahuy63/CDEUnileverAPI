using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Core.Services;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public ICommentService _commentService;
        public readonly IMapper _mapper;
        public CommentsController(ICommentService commentService, IMapper mapper) { 
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCommentByTasK/{jobTaskId}")]
        public async Task<IEnumerable<ShowCommentListDTO>> GetAllByTask(int jobTaskId)
        {
            return _mapper.Map<IEnumerable<ShowCommentListDTO>>(await _commentService.GetAllbyTask(jobTaskId));
        }

        [HttpPost("JobTaskDetail/{jobTaskId}/AddComment")]
        public async Task<IActionResult> AddComment(int jobTaskId, CommentDTO commentDTO)
        {
            var comment = _mapper.Map<Comment>(commentDTO);
            comment.JobTaskId = jobTaskId;
            if (await _commentService.AddComment(comment))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

    }
}

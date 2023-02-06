using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Core.Services;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("GetAllCommentByTasK/{jobTaskId}")]
        public async Task<IEnumerable<ShowCommentListDTO>> GetAllByTask(int jobTaskId)
        {
            return _mapper.Map<IEnumerable<ShowCommentListDTO>>(await _commentService.GetAllbyTask(jobTaskId));
        }

        [Authorize]
        [HttpPost("JobTaskDetail/{jobTaskId}/AddComment")]
        public async Task<IActionResult> AddComment(int jobTaskId, CommentDTO commentDTO)
        {
            var currentUser = GetCurrentUser();
            var comment = _mapper.Map<Comment>(commentDTO);
            comment.JobTaskId = jobTaskId;
            comment.UserId = currentUser.Id;
            if (await _commentService.AddComment(comment))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        private User GetCurrentUser()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;

                return new User
                {
                    Id = Int32.Parse(userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                    Role = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}

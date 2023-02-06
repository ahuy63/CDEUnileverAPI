using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/Notification")]
    [ApiController]
    public class NotiController : ControllerBase
    {
        public INotiService _notiService { get; set; }
        public readonly IMapper _mapper;
        public NotiController(INotiService notiService, IMapper mapper)
        {
            _notiService = notiService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllByUser/{userId}")]    
        public async Task<IActionResult> GetAllByUser(int userId)
        {
            return Ok(_mapper.Map<IEnumerable<ShowNotiListDTO>>(await _notiService.GetAllByUser(userId)));
        }

        [Authorize]
        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification(NotificationDTO notificationDTO)
        {
            if (await _notiService.AddNotification(_mapper.Map<Notification>(notificationDTO)))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet("GetNotification/{id}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var noti = _mapper.Map<ShowNotiListDTO>(await _notiService.GetNotification(id));
            if (noti != null)
            {
                return Ok(noti);
            }
            return NotFound();
        }
    }
}

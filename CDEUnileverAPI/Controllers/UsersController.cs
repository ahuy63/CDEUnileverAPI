using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Core.Services;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _userService { get; set; }
        public readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles = "owner, admin")]
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IEnumerable<ShowUserListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ShowUserListDTO>>( await _userService.GetAll());
        }

        [Authorize(Roles = "owner, admin")]
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(IEnumerable<int> userIdList)
        {
            try
            {
                foreach (var item in userIdList)
                {
                    await _userService.DeleteUser(item);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<ShowUserListDTO>(user));
            }
        }

        [Authorize]
        [HttpPut("{id}/ChangeInfo")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO updateUserDto)
        {
            var updateUser = _mapper.Map<User>(updateUserDto);
            if (await _userService.UpdateUser(id, updateUser))
            {
                return NoContent();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut("{id}/ChangePassword")]
        public async Task<IActionResult> UpdateUserPassword(int id, string newPassword)
        {
            if (await _userService.UpdateUserPassword(id, newPassword))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

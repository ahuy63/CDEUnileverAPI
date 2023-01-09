using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _userService { get; set; }
        public UsersController(IUserService userService)
        {
            _userService= userService;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<IEnumerable<ShowUserListDTO>> GetAll()
        {
            return await _userService.GetAll();
        }

        //[Route("GetUser/{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO updateUserDto)
        {
            if (await _userService.UpdateUser(id, updateUserDto))
            {
                return NoContent();
            }
            return BadRequest();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateUserPassword(int id, string newPassword)
        //{
        //    if (await _userService.UpdateUserPassword(id, newPassword))
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}
    }
}

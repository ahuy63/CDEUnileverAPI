using AutoMapper;
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
        private readonly CDEUnileverDbContext _context;
        public readonly IMapper _mapper;
        public UsersController(CDEUnileverDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var UserList = _context.Users.ToList();
            //var mappedUserList = _mapper.Map<User>(UserList);
            return Ok(UserList);
        }

        //[Route("GetUser/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var user = _context.Users.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<UserDTO>(user));
            }
        }
    }
}

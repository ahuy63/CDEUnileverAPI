using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using AutoMapper;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Core.IServices;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        public IAreaService _areaService { get; set; }
        public IUserService _userService { get; set; }
        public IDistributorService _distributorService { get; set; }
        public readonly IMapper _mapper;
        public AreasController(IAreaService areaService, IUserService userService, IDistributorService distributorService, IMapper mapper)
        {
            _areaService = areaService;
            _userService = userService;
            _distributorService = distributorService;
            _mapper = mapper;
        }

        // GET: api/Areas
        [Route("GetAllArea")]
        [HttpGet]
        public async Task<IEnumerable<ShowAreaDTO>> GetAll()
        {
            var areaList = await _areaService.GetAll();
            return _mapper.Map<IEnumerable<ShowAreaDTO>>(await _areaService.GetAll());
        }

        // GET: api/Areas/5
        //[Route("GetArea/{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {
            var area = await _areaService.GetArea(id);
            if (area == null)
            {
                return NotFound();
            }
            else return Ok(_mapper.Map<ShowAreaDTO>(area));
        }

        // POST: api/Areas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("AddArea")]
        [HttpPost]
        public async Task<IActionResult> AddArea(AddAreaDTO areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);
            if (await _areaService.AddArea(area))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            //return CreatedAtAction("GetArea", new { id = mappedArea.Id });
        }

        // DELETE: api/Areas/5
        //[Route("DeleteArea/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            if (await _areaService.DeleteArea(id))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{areaId}/GetUser")]
        public async Task<IEnumerable<ShowArea_UserDTO>> GetAreaDetails_User(int areaId)
        {
            return _mapper.Map<IEnumerable<ShowArea_UserDTO>>(await _userService.GetUserByAreaId(areaId));
        }

        [HttpGet("{areaId}/GetDistributor")]
        public async Task<IEnumerable<ShowArea_DistributorDTO>> GetAreaDetails_Distributor(int areaId)
        {
            return _mapper.Map<IEnumerable<ShowArea_DistributorDTO>>(await _distributorService.GetDistributorByAreaId(areaId));
        }

        [HttpPut("{areaId}/AssignUser")]
        public async Task<IActionResult> AssignUserToArea(int areaId, int userId)
        {
            var user = await _userService.GetUserDetails(userId);
            if (user != null)
            {
                user.AreaId = areaId;
                await _userService.UpdateUserArea(user, areaId);
                return Ok(_mapper.Map<ShowUserListDTO>(await _userService.GetUser(userId)));
            }
            return BadRequest();
        }

        [HttpPost("{areaId}/AddNewUserToArea")]
        public async Task<IActionResult> AddNewUserToArea(int areaId, AddNewUserToAreaDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.AreaId = areaId;
            var apiResponse = await _userService.AddUser(user);
            if (apiResponse.Result)
            {
                return Ok(apiResponse.Message);
            }
            return BadRequest(apiResponse.Message);
        }

        [HttpPut("RemoveAssignedUser/{userId}")]
        public async Task<IActionResult> RemoveUserFromArea(int userId)
        {
            var user = await _userService.GetUserDetails(userId);
            if (user != null)
            {
                user.AreaId = null;
                await _userService.UpdateUserArea(user, null);
                return Ok(_mapper.Map<ShowUserListDTO>(await _userService.GetUser(userId)));
            }
            return BadRequest();
        }
    }
}

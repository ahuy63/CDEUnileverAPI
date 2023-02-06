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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "owner, admin")]
        [HttpGet]
        public async Task<IEnumerable<ShowAreaDTO>> GetAll()
        {
            var areaList = await _areaService.GetAll();
            return _mapper.Map<IEnumerable<ShowAreaDTO>>(await _areaService.GetAll());
        }

        // GET: api/Areas/5
        //[Route("GetArea/{id}")]
        [Authorize(Roles = "owner, admin")]
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
        [Authorize(Roles = "owner, admin")]
        [HttpPost]
        public async Task<IActionResult> AddArea(AddAreaDTO areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);
            if (await _areaService.AddArea(area))
            {
                return Ok("New Area has been created successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Areas/5
        //[Route("DeleteArea/{id}")]
        [Authorize(Roles = "owner, admin")]
        [HttpDelete("Deletearea")]
        public async Task<IActionResult> DeleteArea(IEnumerable<int> idList)
        {
            try
            {
                foreach (var item in idList)
                {
                    await _areaService.DeleteArea(item);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "owner, admin")]
        [HttpGet("{areaId}/GetUser")]
        public async Task<IActionResult> GetAreaDetails_User(int areaId)
        {   
            var result = _mapper.Map<IEnumerable<ShowArea_UserDTO>>(await _userService.GetUserByAreaId(areaId));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
            //return _mapper.Map<IEnumerable<ShowArea_UserDTO>>(await _userService.GetUserByAreaId(areaId));
        }

        [Authorize(Roles = "owner, admin")]
        [HttpGet("{areaId}/GetDistributor")]
        public async Task<IActionResult> GetAreaDetails_Distributor(int areaId)
        {
            var result = _mapper.Map<IEnumerable<ShowArea_DistributorDTO>>(await _distributorService.GetDistributorByAreaId(areaId));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [Authorize(Roles = "owner, admin")]
        [HttpPut("{areaId}/AssignUser")]
        public async Task<IActionResult> AssignUserToArea(int areaId, int userId)
        {
            var user = await _userService.GetUserDetails(userId);
            if (user != null)
            {
                user.AreaId = areaId;
                await _userService.UpdateUserArea(user, areaId);
                return Ok("done");
            }
            return BadRequest();
        }

        [Authorize(Roles = "owner, admin")]
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

        [Authorize(Roles = "owner, admin")]
        [HttpPut("RemoveAssignedUser")]
        public async Task<IActionResult> RemoveUserFromArea(int userId)
        {
            var user = await _userService.GetUserDetails(userId);
            if (user != null)
            {
                user.AreaId = null;
                await _userService.UpdateUserArea(user, null);
                return Ok("Done");
            }
            return BadRequest();
        }
    }
}

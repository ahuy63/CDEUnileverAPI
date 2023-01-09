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
        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<IEnumerable<ShowAreaDTO>> GetAll()
        {
            var areaList = await _areaService.GetAll();
            return await _areaService.GetAll();
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArea(int id)
        {
            var area = await _areaService.GetArea(id);
            if (area == null)
            {
                return NotFound();
            }
            else return Ok(area);
        }

        // POST: api/Areas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddArea(AddAreaDTO area)
        {
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
        [Route("AddUserToArea")]
        [HttpPost]
        public async Task<IActionResult> AddUserToArea(Area_UserDTO data)
        {
            if (await _areaService.AddUserToArea(data.UserId, data.AreaId))
            {
                return Ok();
            }
            return BadRequest();
        }
        [Route("AddDistributorToArea")]
        [HttpPost]
        public async Task<IActionResult> AddDistributorToArea(Area_DistributorDTO data)
        {
            if (await _areaService.AddDistributorToArea(data.DistributorId, data.AreaId))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

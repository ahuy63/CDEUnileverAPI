using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        public ITitleService _titleService { get; set; }

        public TitlesController(ITitleService titleService)
        {
            _titleService= titleService;
        }

        [Authorize(Roles = "owner, admin")]
        [HttpGet]
        public async Task<IEnumerable<TitleDTO>> GetAll()
        {
            return await _titleService.GetAll();
        }

        [Authorize(Roles = "owner, admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var title = await _titleService.GetTitle(id);
            if (title == null) { 
                return NotFound();
            }
            else
            {
                return Ok(title);
            }
        }

        [Authorize(Roles = "owner, admin")]
        [HttpPost]
        public async Task<IActionResult> Create(TitleDTO titleDto)
        {
            if (await _titleService.AddTitle(titleDto))
            {
                return StatusCode(StatusCodes.Status201Created, titleDto);
            }
            return BadRequest();
        }

        [Authorize(Roles = "owner, admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TitleDTO titleDto)
        {
            if (await _titleService.UpdateTitle(id, titleDto))
            {
                return NoContent();
            }
            return BadRequest();
        }

        [Authorize(Roles = "owner, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _titleService.DeleteTitle(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        
    }
}

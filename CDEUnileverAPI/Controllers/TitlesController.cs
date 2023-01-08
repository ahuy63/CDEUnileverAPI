using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public Task<IEnumerable<Title>> GetAll()
        {
            return _titleService.GetAll();
        }

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

        [HttpPost]
        public async Task<IActionResult> Create(TitleDTO titleDto)
        {
            if (await _titleService.AddTitle(titleDto))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TitleDTO titleDto)
        {
            if (await _titleService.UpdateTitle(id, titleDto))
            {
                return Ok();
            }
            return BadRequest();
        }


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

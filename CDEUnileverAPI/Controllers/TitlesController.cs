using AutoMapper;
using CDEUnileverAPI.Core.IConfiguration;
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
        private readonly CDEUnileverDbContext _context;
        public readonly IMapper _mapper;
        public TitlesController(CDEUnileverDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var TitleList = _context.Titles.ToList();
            return Ok(TitleList);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var title = _context.Titles.FirstOrDefault(t => t.Id == id);
            if (title == null) { 
                return NotFound();
            }
            else
            {
                return Ok(title);
            }
        }

        [HttpPost]
        public IActionResult Create(TitleDTO title)
        {
            try
            {
                var mappedTitle = _mapper.Map<Title>(title);
                _context.Add(mappedTitle);
                _context.SaveChanges();
                return CreatedAtAction("GetById", new { id = mappedTitle.Id }, mappedTitle);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, TitleDTO titleDto)
        {
            try
            {
                var mappedTitle = _mapper.Map<Title>(titleDto);
                var existingTitle = _context.Titles.Where(t => t.Id == id).FirstOrDefault();
                if (existingTitle != null)
                {
                    existingTitle.Name = titleDto.Name;
                    existingTitle.Description = titleDto.Description;
                    _context.SaveChanges();
                    return Ok(existingTitle);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingTitle = _context.Titles.Where(t => t.Id == id).FirstOrDefault();
                if (existingTitle != null)
                {
                    _context.Remove(existingTitle);
                    _context.SaveChanges();
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
        
    }
}

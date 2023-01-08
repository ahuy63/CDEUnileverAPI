using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorsController : ControllerBase
    {
        public IDistributorService _distributorService { get; set; }
        public DistributorsController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _distributorService.GetAll());
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var distributor = await _distributorService.GetDistributor(id);
            if (distributor == null)
            {
                return NotFound();
            }
            return Ok(distributor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DistributorDTO distributorDto)
        {
            if(await _distributorService.AddDistributor(distributorDto))
            {
                return Ok(distributorDto);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _distributorService.DeleteDistributor(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DistributorDTO distributorDto)
        {
            if (await _distributorService.UpdateDistributor(id, distributorDto))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

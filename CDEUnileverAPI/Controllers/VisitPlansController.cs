using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitPlansController : ControllerBase
    {
        public IVisitPlanService _visitPlanService { get; set; }
        public readonly IMapper _mapper;
        public VisitPlansController(IVisitPlanService visitPlanService, IMapper mapper)
        {
            _visitPlanService = visitPlanService;
            _mapper = mapper;
        }

        [HttpGet("GetAllVisitPlan")]
        public async Task<IEnumerable<ShowVisitPlanListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ShowVisitPlanListDTO>>(await _visitPlanService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<VisitPlan> GetById(int id)
        {
            return await _visitPlanService.GetVisitPlan(id);
        }

        [HttpPost("CreateVisitPlan")]
        public async Task<IActionResult> CreateVisitPlan(VisitPlanDTO visitPlanDto)
        {
            foreach (var date in visitPlanDto.Dates)
            {
                var visitPlan = _mapper.Map<VisitPlan>(visitPlanDto);
                visitPlan.Date = date;
                if (!await _visitPlanService.AddVisitPlan(visitPlan))
                {
                    return BadRequest();
                }
            }
            //var visitPlan = _mapper.Map<VisitPlan>(visitPlanDto);
            return StatusCode(StatusCodes.Status201Created, visitPlanDto);
            
        }
    }
}

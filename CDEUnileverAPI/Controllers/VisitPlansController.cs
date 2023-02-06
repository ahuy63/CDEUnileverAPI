using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitPlansController : ControllerBase
    {
        public IVisitPlanService _visitPlanService { get; set; }
        public IJobTaskService _jobTaskService { get; set; }
        public readonly IMapper _mapper;
        public VisitPlansController(IVisitPlanService visitPlanService, IJobTaskService jobTaskService,IMapper mapper)
        {
            _visitPlanService = visitPlanService;
            _jobTaskService = jobTaskService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllVisitPlan")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<ShowVisitPlanListDTO>>(await _visitPlanService.GetAll()));
        }

        [Authorize]
        [HttpGet("VisitPlanDetail/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var visitPlanDetail = _mapper.Map<VisitPlanDetailDTO>(await _visitPlanService.GetVisitPlan(id));
            if (visitPlanDetail != null)
            {
                visitPlanDetail.Tasks = _mapper.Map<ICollection<ShowJobTaskListDTO>>(await _jobTaskService.GetByVisitPlanId(id));
                return Ok(visitPlanDetail);
            }
            return NotFound();
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("Search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            return Ok(_mapper.Map<IEnumerable<ShowVisitPlanListDTO>>(await _visitPlanService.Search(keyword)));
        }
    }
}

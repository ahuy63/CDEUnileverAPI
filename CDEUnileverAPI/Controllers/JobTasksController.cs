using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTasksController : ControllerBase
    {
        public IJobTaskService _jobTaskService { get; set; }
        public readonly IMapper _mapper;
        public JobTasksController(IJobTaskService jobTaskService, IMapper mapper)
        {
            _jobTaskService = jobTaskService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ShowJobTaskListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ShowJobTaskListDTO>>(await _jobTaskService.GetAll());
        }

        [HttpGet("TaskDetail/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = _mapper.Map<ShowJobTaskDetailsDTO>(await _jobTaskService.GetJobTask(id));
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound();
        }

        [HttpGet("GetAllTaskByVisitPlan/{visitPlanId}")]
        public async Task<IEnumerable<ShowJobTaskListDTO>> GetByVisitPlan(int visitPlanId)
        {
            return _mapper.Map<IEnumerable<ShowJobTaskListDTO>>(await _jobTaskService.GetByVisitPlanId(visitPlanId));
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(JobTaskDTO jobTaskDto)
        {
            var jobTask = _mapper.Map<JobTask>(jobTaskDto);
            if (await _jobTaskService.AddJobTask(jobTask))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }


    }
}

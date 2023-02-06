using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Core.Services;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IEnumerable<ShowJobTaskListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ShowJobTaskListDTO>>(await _jobTaskService.GetAll());
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("GetAllTaskByVisitPlan/{visitPlanId}")]
        public async Task<IEnumerable<ShowJobTaskListDTO>> GetByVisitPlan(int visitPlanId)
        {
            return _mapper.Map<IEnumerable<ShowJobTaskListDTO>>(await _jobTaskService.GetByVisitPlanId(visitPlanId));
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("Search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            return Ok(_mapper.Map<IEnumerable<ShowJobTaskListDTO>>(await _jobTaskService.Search(keyword)));
        }

        [Authorize]
        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (await _jobTaskService.DeleteJobTask(id))
            {
                return Ok("Delete successfully");
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut("EditTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, JobTaskDTO jobTaskDTO)
        {
            var mappedTask = _mapper.Map<JobTask>(jobTaskDTO);
            mappedTask.Id = id;
            if (await _jobTaskService.UpdateJobTask(mappedTask))
            {
                return Ok("Update successfully");
            }
            return BadRequest();
        }
    }
}

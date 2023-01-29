using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTasksController : ControllerBase
    {
        public IJobTaskService _jobTaskService { get; set; }
        public JobTasksController(IJobTaskService jobTaskService)
        {
            _jobTaskService = jobTaskService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<JobTask>> GetAll()
        {
            return await _jobTaskService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<JobTask> GetById(int id)
        {
            return await _jobTaskService.GetJobTask(id);
        }
    }
}

using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        public readonly IMapper _mapper;
        public ISurveyService _surveyService;
        public ISurveyAnswerService _surveyAnswerService;
        public IParticipantService _participantService;
        public SurveysController(ISurveyService surveyService, 
            ISurveyAnswerService surveyAnswerService, 
            IParticipantService participantService, 
            IMapper mapper)
        {
            _surveyService= surveyService;
            _surveyAnswerService= surveyAnswerService;
            _participantService=participantService;
            _mapper=mapper;
        }

        [Authorize]
        [HttpGet("GetAllSurvey")]
        public async Task<IActionResult> GetAll()
        {
            var surveyList = await _surveyService.GetAll();
            var surveyListDTO = _mapper.Map<IEnumerable<SurveyListDTO>>(surveyList);
            //foreach (var item in surveyList)
            //{
            //    var list = item.Participants.Count();
            //}
            return Ok(surveyListDTO);
        }

        [Authorize]
        [HttpPost("CreateSurveyRequest")]
        public async Task<IActionResult> CreateSurveyRequest(SurveyDTO surveyDto)
        {
            if (await _surveyService.Add(_mapper.Map<Survey>(surveyDto)))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyResult(int id)
        {
            var result = _mapper.Map<SurveyDetailDTO>(await _surveyService.SurveyResult(id));
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        private User GetCurrentUser()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;

                return new User
                {
                    Id = Int32.Parse(userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                    Role = userClaim.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}

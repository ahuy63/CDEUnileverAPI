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
    public class ParticipantsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public ISurveyService _surveyService;
        public ISurveyAnswerService _surveyAnswerService;
        public IParticipantService _participantService;
        public ParticipantsController(IMapper mapper, ISurveyService surveyService, ISurveyAnswerService surveyAnswerService, IParticipantService participantService)
        {
            _mapper = mapper;
            _surveyService = surveyService;
            _surveyAnswerService = surveyAnswerService;
            _participantService = participantService;
        }


        [Authorize(Roles = "Participant")]
        [HttpPost("DoSurvey/")]
        public async Task<IActionResult> SurveyAnswer(IEnumerable<SurveyAnswerDTO> ansDto)
        {
            var answers = _mapper.Map<IEnumerable<SurveyAnswer>>(ansDto);
            var currentUser = GetCurrentUser();
            if (await _surveyService.SurveyAnswer(currentUser.Id,answers))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
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

using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

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


        [HttpPost("{participantId}/Survey/")]
        public async Task<IActionResult> SurveyAnswer(int participantId,IEnumerable<SurveyAnswerDTO> ansDto)
        {
            var answers = _mapper.Map<IEnumerable<SurveyAnswer>>(ansDto);
            if (await _surveyService.SurveyAnswer(participantId,answers))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }
    }
}

using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        public IQuestionnaireService _questionaireService { get; set; }
        public IQuestionnaireDetailService _questionaireDetailService { get; set; }
        public readonly IMapper _mapper;
        public SurveyController(IQuestionnaireService questionaireService, IQuestionnaireDetailService questionaireDetailService, IMapper mapper)
        {
            _questionaireService = questionaireService;
            _questionaireDetailService = questionaireDetailService;
            _mapper = mapper;
        }

        [HttpGet("GetAllQuestionaires")]
        public async Task<IEnumerable<ShowAllQuestionaireDTO>> GetAllQuestionaires()
        {
            return _mapper.Map<IEnumerable<ShowAllQuestionaireDTO>>(await _questionaireService.GetAll());
        }

        //[HttpGet("{id}")]
        //public async Task<>

        [HttpPost("AddNewQuestionnaire")]
        public async Task<IActionResult> AddNewQuestionaire(AddNewQuestionaireDTO questionaireDto)
        {
            var questionaire = _mapper.Map<Questionnaire>(questionaireDto);
            if (await _questionaireService.AddNew(_mapper.Map<Questionnaire>(questionaire)))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        [HttpPut("UpdateQuestionnaire/{id}")]
        public async Task<IActionResult> UpdateQuesntionaireTitle(int id, AddNewQuestionaireDTO questionaireDto)
        {
            var questionaire = _mapper.Map<Questionnaire>(questionaireDto);
            if (await _questionaireService.UpdateQuestionaire(id, questionaire))
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("GetQuestionnaireDetails/{id}")]
        public async Task<QuestionnaireDetailsDTO> GetQuestionaireDetails(int id)
        {
            var questionnaireDetail = await _questionaireService.GetQuestionaire(id);
            var questionnaireDetailDto = _mapper.Map<QuestionnaireDetailsDTO>(questionnaireDetail);
            var b = questionnaireDetail.Questions.FirstOrDefault();
            var a = _mapper.Map<ShowQuestionDTO>(b);
            questionnaireDetailDto.Questions = _mapper.Map<ICollection<ShowQuestionDTO>>(questionnaireDetail.Questions);
            return questionnaireDetailDto;
        }

        [HttpPost("Questionnaire/{questionnaireId}/AddQuestion")]
        public async Task<IActionResult> AddQuestiontoQuestionaire(int questionnaireId,AddNewQuestionDTO addNewQuestionDTO)
        {
            var question = _mapper.Map<QuestionnaireDetail>(addNewQuestionDTO);
            question.QuestionnaireId = questionnaireId;
            if(await _questionaireService.AddNewQuestion(question))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        [HttpPut("UpdateQuestion/{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, AddNewQuestionDTO questionDto)
        {
            var question = _mapper.Map<QuestionnaireDetail>(questionDto);
            if (await _questionaireService.UpdateQuestion(id, question))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

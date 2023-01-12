using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionairesController : ControllerBase
    {
        public IQuestionaireService _questionaireService { get; set; }
        public IQuestionaireDetailService _questionaireDetailService { get; set; }
        public readonly IMapper _mapper;
        public QuestionairesController(IQuestionaireService questionaireService, IQuestionaireDetailService questionaireDetailService, IMapper mapper)
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

        [HttpPost]
        public async Task<IActionResult> AddNewQuestionaire(AddNewQuestionaireDTO questionaireDto)
        {
            var questionaire = _mapper.Map<Questionaire>(questionaireDto);
            if (await _questionaireService.AddNew(_mapper.Map<Questionaire>(questionaire)))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuesntionaireTitle(int id, AddNewQuestionaireDTO questionaireDto)
        {
            var questionaire = _mapper.Map<Questionaire>(questionaireDto);
            if (await _questionaireService.UpdateQuestionaire(id, questionaire))
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}

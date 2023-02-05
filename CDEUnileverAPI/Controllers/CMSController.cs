using AutoMapper;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.DTO;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CDEUnileverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSController : ControllerBase
    {
        public ICMSService _cmsService { get; set; }
        public readonly IMapper _mapper;
        public CMSController(ICMSService cmsService, IMapper mapper) { 
            _cmsService = cmsService;
            _mapper = mapper;
        }

        [HttpGet("GetAllArticle")]
        public async Task<IActionResult> GetAllArticle()
        {
            return Ok(_mapper.Map<IEnumerable<ShowArticleListDTO>>( await _cmsService.GetAll()));
        }

        [HttpGet("GetArticle/{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _cmsService.GetArticle(id);
            if (article != null)
            {
                return Ok(_mapper.Map<ArticleDetailDTO>( article));
            }
            return NotFound();
        }

        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticle(ArticleDTO articleDto)
        {
            if (await _cmsService.AddArticle(_mapper.Map<Article>(articleDto)))
            {
                return Ok("New Article has been created successfully"); 
            }
            return BadRequest();
        }

        [HttpDelete("DeleteArticle/{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            if (await _cmsService.DeleteArticle(id))
            {
                return Ok("Delete successfully");
            }
            return BadRequest();
        }

        [HttpPut("EditArticle/{id}")]
        public async Task<IActionResult> UpdateArticle(int id, UpdateArticleDTO articleDto)
        {
            var mappedArticle = _mapper.Map<Article>(articleDto);
            mappedArticle.Id = id;
            if (await _cmsService.UpdateArticle(mappedArticle))
            {
                return Ok("Update successfully");
            }
            return BadRequest();
        }

        [HttpPut("PublishArticle/{id}")]
        public async Task<IActionResult> PublishArticle(int id)
        {
            var article = await _cmsService.GetArticle(id);
            article.IsPublished = true;
            if (await _cmsService.UpdateArticle(article))
            {
                return Ok("Article is published successfully");
            }
            return BadRequest();
        }

        [HttpPut("UnpublishArticle/{id}")]
        public async Task<IActionResult> UnpublishArticle(int id)
        {
            var article = await _cmsService.GetArticle(id);
            article.IsPublished = false;
            if (await _cmsService.UpdateArticle(article))
            {
                return Ok("Article is unpublished successfully");
            }
            return BadRequest();
        }

    }
}

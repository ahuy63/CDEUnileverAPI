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
    public class CMSController : ControllerBase
    {
        public ICMSService _cmsService { get; set; }
        public readonly IMapper _mapper;
        
        public CMSController(ICMSService cmsService, IMapper mapper) { 
            _cmsService = cmsService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllArticle")]
        public async Task<IActionResult> GetAllArticle()
        {
            return Ok(_mapper.Map<IEnumerable<ShowArticleListDTO>>( await _cmsService.GetAll()));
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("AddArticle")]
        public async Task<IActionResult> AddArticle(ArticleDTO articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var currentUser = GetCurrentUser();
            article.CreatedById =  currentUser.Id;
            if (await _cmsService.AddArticle(article))
            {
                return Ok("New Article has been created successfully"); 
            }
            return BadRequest();
        }

        [Authorize]
        [HttpDelete("DeleteArticle/{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            if (await _cmsService.DeleteArticle(id))
            {
                return Ok("Delete successfully");
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPut("EditArticle/{id}")]
        public async Task<IActionResult> UpdateArticle(int id, UpdateArticleDTO articleDto)
        {
            var article = await _cmsService.GetArticle(id);
            //var mappedArticle = _mapper.Map<Article>(articleDto);
            _mapper.Map<UpdateArticleDTO, Article>(articleDto, article);
            article.Id = id;
            if (await _cmsService.UpdateArticle(article))
            {
                return Ok("Update successfully");
            }
            return BadRequest();
        }

        [Authorize]
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

        [Authorize]
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

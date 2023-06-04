using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Medium.Infrasturucture.Services.Entities.Abstractions;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        readonly IArticleService _articleService;
        readonly IAuthService _userService;

        public ArticlesController(IArticleService articleService, IAuthService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<GetArticleDto>>> Articles([FromForm] AddArticleDto articleDto)
        {
            var user = await _userService.GetCurrentUser();
            var response = await _articleService.AddArticle(articleDto, user.Id);
            return Ok(response);
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<NoDataDto>>> DeleteArticles(int id)
        {
            var user = await _userService.GetCurrentUser();
            var response = await _articleService.DeleteArticle(id, user);
            return Ok(response);
        }

        [HttpPut("id")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<NoDataDto>>> UpdateArticles(AddArticleDto addArticleDto, int id)
        {
            var user = await _userService.GetCurrentUser();
            var response = await _articleService.UpdateArticle(addArticleDto, id, user);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<NoDataDto>>> Articles()
        {
            var response = await _articleService.GetArticles();
            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<NoDataDto>>> Article(int id)
        {
            var response = await _articleService.GetArticle(id);
            return Ok(response);
        }

        [HttpGet("userId")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<NoDataDto>>> ArticleByUser(int userId)
        {
            var response = await _articleService.GetArticlesByOwner(userId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<NoDataDto>>> ArticleByUser(IEnumerable<int> ids)
        {
            var response = await _articleService.GetArticlesWhere(ids);
            return Ok(response);
        }
    }
}

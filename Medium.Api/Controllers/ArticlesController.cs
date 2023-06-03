using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Medium.Infrasturucture.Services.Entities.Abstractions;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
        public async Task<ActionResult<Response<GetArticleDto>>> Articles([FromForm] AddArticleDto articleDto)
        {
            var user = await _userService.GetCurrentUser();
            var response = await _articleService.AddArticle(articleDto, user.Id);
            return Ok(response);
        }

        //[HttpDelete("id")]
        //public Task<ActionResult<Response<NoDataDto>>> Articles(int id)
        //{
        //    var 
        //}

    }
}

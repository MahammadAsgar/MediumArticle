using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Users.Get;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Result;

namespace Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IAuthService _authService;
        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPut]
        public async Task<ActionResult<Response<NoDataDto>>> LikeArticle(int articleId)
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.LikeArticle(user, articleId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response<NoDataDto>>> FollowUser(int userId)
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.FollowUser(user, userId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response<NoDataDto>>> UnFollowUser(int userId)
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.UnFollowUser(user, userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetUserOnList>>>> Followers(int userId)
        {
            var response = await _userService.Followers(userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetUserOnList>>>> Followings(int userId)
        {
            var response = await _userService.Followings(userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetArticleDto>>>> LikedArticles()
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.LikedArticles(user);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetTagDto>>>> UsedTags()
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.UsedTags(user);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetTagDto>>>> SelectedTags()
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.SelectedTags(user);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<GetArticleTagsDto>>>> ArticlesByUser()
        {
            var user = await _authService.GetCurrentUser();
            var response = await _userService.ArticlesByUser(user);
            return Ok(response);
        }


    }
}

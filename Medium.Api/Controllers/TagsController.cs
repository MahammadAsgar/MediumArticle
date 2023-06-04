using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Medium.Infrasturucture.Services.Entities.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Result;

namespace Medium.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class TagsController : ControllerBase
    {
        readonly ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<GetTagDto>>> Tags([FromForm] AddTagDto tagDto)
        {
            var response = await _tagService.AddTag(tagDto);
            return Ok(response);
        }

        [HttpPut("id")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<GetTagDto>>> Tags([FromForm] AddTagDto tagDto, int id)
        {
            var response = await _tagService.UpdateTag(tagDto, id);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("id")]
        public async Task<ActionResult<Response<GetTagDto>>> Tags(int id)
        {
            var response = await _tagService.DeleteTag(id);
            return Ok(response);
        }

        [HttpGet("id")]
        [Authorize(Roles = "Admin, User")]

        public async Task<ActionResult<Response<GetTagDto>>> Tag(int id)
        {
            var response = await _tagService.GetTag(id);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<Response<IEnumerable<GetTagDto>>>> Tags()
        {
            var response = await _tagService.GetTags();
            return Ok(response);
        }
    }
}

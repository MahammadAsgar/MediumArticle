using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Result;

namespace Medium.Infrasturucture.Services.Entities.Abstractions
{
    public interface ITagService
    {
        Task<Response<GetTagDto>> AddTag(AddTagDto addTagDto);
        Task<Response<GetTagDto>> UpdateTag(AddTagDto addTagDto, int id);
        Task<Response<NoDataDto>> DeleteTag(int id);
        Task<Response<GetTagDto>> GetTag(int id);
        Task<Response<IEnumerable<GetTagDto>>> GetTags();
    }
}

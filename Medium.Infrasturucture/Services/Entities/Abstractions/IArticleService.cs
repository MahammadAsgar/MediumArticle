using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Result;

namespace Medium.Infrasturucture.Services.Entities.Abstractions
{
    public interface IArticleService
    {
        Task<Response<GetArticleDto>> AddArticle(AddArticleDto addArticleDto, int userId);
        Task<Response<GetArticleDto>> UpdateArticle(AddArticleDto addArticleDto, int id);
        Task<Response<NoDataDto>> DeleteArticle(int id);
        Task<Response<GetArticleDto>> GetArticle(int id);
        Task<Response<IEnumerable<GetArticleDto>>> GetArticles();
    }
}

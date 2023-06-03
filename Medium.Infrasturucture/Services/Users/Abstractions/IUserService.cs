using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Users.Get;
using Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Infrasturucture.Services.Users.Abstractions
{
    public interface IUserService
    {
        Task<Response<NoDataDto>> LikeArticle(AppUser user, int articleId);
        Task<Response<NoDataDto>> FollowUser(AppUser user, int userId);
        Task<Response<NoDataDto>> UnFollowUser(AppUser user, int userId);
        Task<Response<IEnumerable<GetUserOnList>>> Followers(int userId);
        Task<Response<IEnumerable<GetUserOnList>>> Followings(int userId);
        Task<Response<IEnumerable<GetArticleDto>>> LikedArticles(AppUser user);
        Task<Response<IEnumerable<GetTagDto>>> UsedTags(AppUser user);
        Task<Response<IEnumerable<GetTagDto>>> SelectedTags(AppUser user);
        Task<Response<IEnumerable<GetArticleTagsDto>>> ArticlesByUser(AppUser user);
    }
}

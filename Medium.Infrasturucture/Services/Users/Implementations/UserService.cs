using AutoMapper;
using Medium.Application.Repositories.Abstractions;
using Medium.Application.UnitOfWorks;
using Medium.Domain.Entities;
using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Users.Get;
using Medium.Infrasturucture.Services.Users.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Infrasturucture.Services.Users.Implementations
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly UserManager<AppUser> _userManager;
        readonly IGenericRepository<Article> _articleRepository;
        readonly IGenericRepository<Tag> _tagRepository;
        readonly IMapper _mapper;
        // readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager,
            IGenericRepository<Article> articleRepository, IGenericRepository<Tag> tagRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetUserOnList>>> Followers(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var followers = user.Followers.ToList();
            if (followers.Count > 0)
            {
                return Response<IEnumerable<GetUserOnList>>.Success(_mapper.Map<IEnumerable<GetUserOnList>>(followers));
            }
            return Response<IEnumerable<GetUserOnList>>.Success("No Followers");
        }

        public async Task<Response<IEnumerable<GetUserOnList>>> Followings(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var followings = new List<int>();
            followings = user.Followings.ToList();
            if (followings.Count > 0)
            {
                return Response<IEnumerable<GetUserOnList>>.Success(_mapper.Map<IEnumerable<GetUserOnList>>(followings));
            }
            return Response<IEnumerable<GetUserOnList>>.Success("No Followings");
        }

        public async Task<Response<NoDataDto>> FollowUser(AppUser user, int targetUser)
        {
            var target = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == targetUser);
            user.Followings = new List<int>();
            user.Followings.Add(target.Id);
            target.Followers = new List<int>();
            target.Followers.Add(target.Id);
            await _userManager.UpdateAsync(user);
            _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success("Successfull add follewers");
        }

        public async Task<Response<NoDataDto>> LikeArticle(AppUser user, int articleId)
        {
            var article = await _articleRepository.GetByIdAsync(articleId);
            article.Likes++;
            user.LikedArticles = new List<Article>();
            user.LikedArticles.Add(article);
            await _userManager.UpdateAsync(user);
            return Response<NoDataDto>.Success("Successfull Liked");
        }

        public async Task<Response<IEnumerable<GetArticleDto>>> LikedArticles(AppUser user)
        {
            var articles = user.LikedArticles;
            if (articles.Count > 0)
            {
                return Response<IEnumerable<GetArticleDto>>.Success(_mapper.Map<IEnumerable<GetArticleDto>>(articles));
            }
            return Response<IEnumerable<GetArticleDto>>.Success("No Data found");
        }

        public async Task<Response<IEnumerable<GetTagDto>>> SelectedTags(AppUser user)
        {
            var tags = user.SelectedTags;
            if (tags.Count > 0)
            {
                return Response<IEnumerable<GetTagDto>>.Success(_mapper.Map<IEnumerable<GetTagDto>>(tags));
            }
            return Response<IEnumerable<GetTagDto>>.Success("No Data found");
        }

        public async Task<Response<NoDataDto>> UnFollowUser(AppUser user, int targetUser)
        {
            var target = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == targetUser);
            user.Followings = new List<int>();
            user.Followings.Remove(target.Id);
            target.Followers = new List<int>();
            target.Followers.Remove(user.Id);
            await _userManager.UpdateAsync(user);
            return Response<NoDataDto>.Success("Successfull remove follewer");
        }

        public async Task<Response<IEnumerable<GetTagDto>>> UsedTags(AppUser user)
        {
            var tags = user.UsedTags;
            if (tags.Count > 0)
            {
                return Response<IEnumerable<GetTagDto>>.Success(_mapper.Map<IEnumerable<GetTagDto>>(tags));
            }
            return Response<IEnumerable<GetTagDto>>.Success("No Data found");
        }

        public async Task<Response<IEnumerable<GetArticleTagsDto>>> ArticlesByUser(AppUser user)
        {
            var articles = user.Articles;
            if (articles.Count > 0)
            {
                return Response<IEnumerable<GetArticleTagsDto>>.Success(_mapper.Map<IEnumerable<GetArticleTagsDto>>(articles));
            }
            return Response<IEnumerable<GetArticleTagsDto>>.Fail("No Data Found");
        }
    }
}

using AutoMapper;
using Medium.Application.Repositories.Abstractions;
using Medium.Application.UnitOfWorks;
using Medium.Domain.Entities;
using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Medium.Infrasturucture.Services.Entities.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Result;
using System.Runtime.CompilerServices;

namespace Medium.Infrasturucture.Services.Entities.Implementations
{
    public class ArticleService : IArticleService
    {
        readonly IGenericRepository<Article> _genericRepository;
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;
        public ArticleService(IGenericRepository<Article> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<GetArticleDto>> AddArticle(AddArticleDto addArticleDto, int userId)
        {
            var article = _mapper.Map<Article>(addArticleDto);
            await _genericRepository.AddAsync(article);
            await _unitOfWork.CommitAsync();
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.Articles = new List<Article>();
            user.Articles.Add(article);
            await _userManager.UpdateAsync(user);
            return Response<GetArticleDto>.Success(_mapper.Map<GetArticleDto>(article));
        }

        public async Task<Response<NoDataDto>> DeleteArticle(int id, AppUser user)
        {

            var article = await _genericRepository.GetByIdAsync(id);
            user.Articles = new List<Article>();
            if (article != null && user.Articles.Contains(article))
            {
                _genericRepository.Remove(article);
                _unitOfWork.Commit();
                return Response<NoDataDto>.Success("Removed Sucessful");
            }
            return Response<NoDataDto>.Fail("Removed Unsuccessful");
        }

        public async Task<Response<GetArticleDto>> GetArticle(int id)
        {
            var article = await _genericRepository.GetByIdAsync(id);
            if (article != null)
            {
                return Response<GetArticleDto>.Success(_mapper.Map<GetArticleDto>(article));
            }
            return Response<GetArticleDto>.Fail("No article found");
        }

        public async Task<Response<IEnumerable<GetArticleDto>>> GetArticles()
        {
            var article = await _genericRepository.GetAllAsync();
            if (article != null)
            {
                return Response<IEnumerable<GetArticleDto>>.Success(_mapper.Map<IEnumerable<GetArticleDto>>(article));
            }
            return Response<IEnumerable<GetArticleDto>>.Fail("No article found");
        }

        public async Task<Response<IEnumerable<GetArticleDto>>> GetArticlesByOwner(int userId)
        {
            var user= await _userManager.Users.FirstOrDefaultAsync(x=>x.Id==userId);
            if (user.Articles.Any())
            {
                return Response<IEnumerable<GetArticleDto>>.Success(_mapper.Map<IEnumerable<GetArticleDto>>(user.Articles));
            }
            return Response<IEnumerable<GetArticleDto>>.Fail("No Data found");
        }

        public async Task<Response<IEnumerable<GetArticleDto>>> GetArticlesWhere(IEnumerable<int> ids)
        {
            var articles = await _genericRepository.Where(x => x.Tags.All(y => ids.Contains(y.Id))).ToListAsync();
            if (articles != null)
            {
                return Response<IEnumerable<GetArticleDto>>.Success(_mapper.Map<IEnumerable<GetArticleDto>>(articles));
            }
            return Response<IEnumerable<GetArticleDto>>.Fail("No data found");
        }

        public async Task<Response<GetArticleDto>> UpdateArticle(AddArticleDto addArticleDto, int id, AppUser user)
        {
            var article = await _genericRepository.GetByIdAsync(id);
            user.Articles = new List<Article>();
            if (article != null && user.Articles.Contains(article))
            {
                if (!string.IsNullOrEmpty(addArticleDto.Title))
                {
                    article.Title = addArticleDto.Title;
                }

                if (!string.IsNullOrEmpty(addArticleDto.Content))
                {
                    article.Content = addArticleDto.Content;
                }

                if (addArticleDto.TagIds.Any())
                {
                    
                }
                 _genericRepository.Update(article);
                _unitOfWork.Commit();

                return Response<GetArticleDto>.Success(_mapper.Map<GetArticleDto>(article));
            }
            return Response<GetArticleDto>.Fail("data not found");
        }
    }
}

using AutoMapper;
using Medium.Domain.Entities;
using Medium.Domain.Users;
using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Medium.Infrasturucture.Dtos.Users.Get;
using Medium.Infrasturucture.Dtos.Users.Post;

namespace Medium.Infrasturucture.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Entities
            CreateMap<Article, AddArticleDto>().ReverseMap();
            CreateMap<Article, GetArticleDto>().ReverseMap();
            CreateMap<ArticleFile, GetArticleFileDto>().ReverseMap();

            CreateMap<Tag, AddTagDto>().ReverseMap();
            CreateMap<Tag, GetTagDto>().ReverseMap();
            #endregion

            #region Users
            CreateMap<AppUser, RegistrUserDto>().ReverseMap();
            CreateMap<AppUser, LoginUserDto>()
                //.ForMember(x=>x.UserNameOrEmail, y=>y.MapFrom(z=>z.Email))
                //.ForMember(x=>x.UserNameOrEmail, y=>y.MapFrom(z=>z.UserName))
                .ReverseMap();
            CreateMap<AppUser, GetUserOwnInfo>().ReverseMap();
            CreateMap<AppUser, GetUserAll>().ReverseMap();
            CreateMap<AppUser, GetUserOnList>().ReverseMap();
            #endregion
        }
    }
}

using Medium.Infrasturucture.Dtos.Entities.Get;

namespace Medium.Infrasturucture.Dtos.Users.Get
{
    public class GetUserOwnInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<GetArticleDto> Articles { get; set; }
       // public ICollection<GetUserOnList> Follewers { get; set; }
        //public ICollection<GetUserOnList> Followings { get; set; }
        public ICollection<GetTagDto> SelectedTags { get; set; }
        public ICollection<GetTagDto> UsedTags { get; set; }
        public ICollection<GetArticleTagsDto> LikedArticles { get; set; }
    }
}

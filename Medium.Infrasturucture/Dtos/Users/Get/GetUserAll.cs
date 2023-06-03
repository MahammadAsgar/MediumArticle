using Medium.Infrasturucture.Dtos.Entities.Get;

namespace Medium.Infrasturucture.Dtos.Users.Get
{
    public class GetUserAll
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public ICollection<GetArticleDto> Articles { get; set; }
        public ICollection<GetTagDto> UsedTags { get; set; }
    }
}

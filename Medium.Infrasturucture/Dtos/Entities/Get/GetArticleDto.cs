namespace Medium.Infrasturucture.Dtos.Entities.Get
{
    public class GetArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<GetTagDto> Tags { get; set; }
        public ICollection<GetArticleFileDto> ArticleFiles { get; set; }
        public int Likes { get; set; }
    }
}

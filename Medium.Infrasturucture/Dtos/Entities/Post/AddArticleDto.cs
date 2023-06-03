namespace Medium.Infrasturucture.Dtos.Entities.Post
{
    public class AddArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<int> TagIds { get; set; }
        //public ICollection<ArticleFile> ArticleFiles { get; set; }
    }
}

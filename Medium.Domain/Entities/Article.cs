using Medium.Domain.Base;
using Medium.Domain.Users;

namespace Medium.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<ArticleFile> ArticleFiles { get; set; }
        //public int OwnerId { get; set; }
        //public AppUser Owner { get; set; }
        public int Likes { get; set; }
    }
}

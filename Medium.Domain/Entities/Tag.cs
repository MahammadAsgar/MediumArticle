using Medium.Domain.Base;

namespace Medium.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}

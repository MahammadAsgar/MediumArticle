
using Medium.Domain.Base;

namespace Medium.Domain.Entities
{
    public class ArticleFile : ProjectFile
    {
        public Article Article { get; set; }
    }
}

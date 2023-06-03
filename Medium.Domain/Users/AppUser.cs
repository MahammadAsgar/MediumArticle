using Medium.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Medium.Domain.Users
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Follewers { get; set; }
        public ICollection<AppUser> Followings { get; set; }
        public ICollection<Tag> SelectedTags { get; set; }
        public ICollection<Tag> UsedTags { get; set; }
        public ICollection<Article> LikedArticles { get; set; }
    }
}

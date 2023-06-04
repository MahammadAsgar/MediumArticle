using Medium.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medium.Domain.Users
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public ICollection<Article> Articles { get; set; }
        [NotMapped]
        public ICollection<int> Followers { get; set; }
        [NotMapped]
        public ICollection<int> Followings { get; set; }
        public ICollection<Tag> SelectedTags { get; set; }
        public ICollection<Tag> UsedTags { get; set; }
        public ICollection<Article> LikedArticles { get; set; }
    }
}

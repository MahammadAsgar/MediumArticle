using Medium.Application.EntitiesConfiguration;
using Medium.Domain.Entities;
using Medium.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medium.Application.Context
{
    public class ArticleDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}

using Medium.Application.Context;

namespace Medium.Application.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArticleDbContext _articleDbContext;
        public UnitOfWork(ArticleDbContext articleDbContext)
        {
            _articleDbContext = articleDbContext;
        }

        public void Commit()
        {
            _articleDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _articleDbContext.SaveChangesAsync();
        }
    }
}
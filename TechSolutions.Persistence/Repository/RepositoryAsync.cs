using Ardalis.Specification.EntityFrameworkCore;
using TechSolutions.Application.Interfaces;
using TechSolutions.Persistence.Contexts;

namespace TechSolutions.Persistence.Repository
{
    public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly TechSolutionsDbContext _dbContext;

        public RepositoryAsync(TechSolutionsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

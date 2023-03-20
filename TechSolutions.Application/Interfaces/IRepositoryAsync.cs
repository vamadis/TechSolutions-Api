using Ardalis.Specification;

namespace TechSolutions.Application.Interfaces
{
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
    }
    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {
    }
}

using AutoMapper;
using TechSolutions.Application.Behaviours;
using TechSolutions.Application.Interfaces;
using TechSolutions.Domain.Entities;
using TechSolutions.Persistence.Contexts;
using TechSolutions.Persistence.Repository;
using Xunit;

namespace TechSolutions.Test.Permission
{
    public class PermissionTest
    {
        private readonly PermissionRepository _CreateRequest;
        private readonly PermissionValidator _validationRules;
        private readonly TechSolutionsDbContext _context;
        private readonly IRepositoryAsync<Permiso> _repositoryAsync;
        private readonly IMapper _mapper;

        public PermissionTest()
        {
            _CreateRequest = new PermissionRepository(_context, _mapper, _validationRules, _repositoryAsync);
        }
        [Fact]
        public void GetVerifyCreateRequestIsNotNull()
        {
            bool? result = _CreateRequest.Equals(_repositoryAsync);
            Assert.NotNull(result);
        }
        [Fact]
        public void GetVerifyDeleteRequestIsNotNull()
        {
            bool? result = _CreateRequest.Equals(_repositoryAsync);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetVerifyUpdateRequestIsNotNull()
        {
            bool? result = _CreateRequest.Equals(_repositoryAsync);
            Assert.NotNull(result);
        }
    }
   
}

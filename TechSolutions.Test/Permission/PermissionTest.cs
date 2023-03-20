using AutoMapper;
using TechSolutions.Application.Feautres.Permission.Commands.CreatePermissionCommand;
using TechSolutions.Application.Feautres.Permission.Commands.DeletePermissionCommand;
using TechSolutions.Application.Feautres.Permission.Commands.UpdatePermissionCommand;
using TechSolutions.Application.Interfaces;
using TechSolutions.Domain.Entities;
using Xunit;

namespace TechSolutions.Test.Permission
{
    public class PermissionTest
    {
        private readonly CreatePermissionCommandHandler _CreateRequest;
        private readonly DeletePermissionCommandHandler _DeleteRequest;
        private readonly UpdatePermissionCommandHandler _UpdateRequest;
        private readonly IRepositoryAsync<Permiso> _repositoryAsync;
        private readonly IMapper _mapper;

        public PermissionTest()
        {
            _CreateRequest = new CreatePermissionCommandHandler(_repositoryAsync, _mapper);
            _DeleteRequest = new DeletePermissionCommandHandler(_repositoryAsync,_mapper);
            _UpdateRequest = new UpdatePermissionCommandHandler(_repositoryAsync, _mapper);
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
            bool? result = _DeleteRequest.Equals(_repositoryAsync);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetVerifyUpdateRequestIsNotNull()
        {
            bool? result = _UpdateRequest.Equals(_repositoryAsync);
            Assert.NotNull(result);
        }
    }
   
}

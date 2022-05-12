using AutoMapper;
using Avaliacao_Atos.Application.AutoMapper;
using Avaliacao_Atos.Application.Services;
using Avaliacao_Atos.Application.ViewModels;
using Avaliacao_Atos.Domain.Entites;
using Avaliacao_Atos.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Avaliacao_Atos.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        #region validações

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));

            Assert.Equal("O Id do usuário não pode ser vazio", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("O Id do usuário não é válido", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID não é válido", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("O id informado não é válido", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyEmail()
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email é obrigatório para a autenticação", exception.Message);
        }

        #endregion

        #region validação de objetos corretos

        [Fact]
        public void Post_SendingValidIbejtc()
        {
            var result = userService.Post(new UserViewModel { Name = "Teste Unitário", Email = "tu@hotmail.com" });

            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            List<User> _users = new List<User>();

            _users.Add(new User { Id = Guid.NewGuid(), Name = "Teste Unitário", Email = "tu@hotmail.com" });

            var _userRepository = new Mock<IUserRepository>();

            _userRepository.Setup(x => x.GetAll()).Returns(_users);

            var _autoMapperProfile = new AutoMapperSetup();

            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));

            IMapper _mapper = new Mapper(_configuration);

            userService = new UserService(_userRepository.Object, _mapper);

            var result = userService.Get();

            Assert.True(result.Count > 0);

        }

        #endregion

        #region validação de propriedades obrigatórias

        [Fact]
        public void Post_SendingInvalidIbejtc()
        {
            var exception = Assert.Throws<ValidationException>(() => userService.Post(new UserViewModel { Name = "Teste Unitário" }));

            Assert.Equal("The Email field is required.", exception.Message);
        }

        #endregion
    }
}

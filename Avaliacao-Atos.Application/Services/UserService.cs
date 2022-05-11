using AutoMapper;
using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.ViewModels;
using Avaliacao_Atos.Auth.Services;
using Avaliacao_Atos.Domain.Entites;
using Avaliacao_Atos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Avaliacao_Atos.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("O Id do usuário não é válido");

            User user = userRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            return mapper.Map<UserViewModel>(user);
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            IEnumerable<User> users = userRepository.GetAll();

            userViewModels = mapper.Map<List<UserViewModel>>(users);

            return userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            if (userViewModel.Id != Guid.Empty)
                throw new Exception("O Id do usuário não pode ser vazio");

            Validator.ValidateObject(userViewModel, new ValidationContext(userViewModel), true);

            User user = mapper.Map<User>(userViewModel);

            userRepository.Create(user);

            return true;
        }

        public bool Put(UserViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("ID não é válido");

            User user = userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            user = mapper.Map<User>(userViewModel);

            userRepository.Update(user);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("O id informado não é válido");

            User user = userRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            return userRepository.Delete(user);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email))
                throw new Exception("Email é obrigatório para a autenticação");

            User _user = userRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == user.Email.ToLower());

            if (_user == null)
                throw new Exception("Usuário não encontrado");

            return new UserAuthenticateResponseViewModel(mapper.Map<UserViewModel>(_user), TokenService.GenerateToken(_user));

        }
    }
}

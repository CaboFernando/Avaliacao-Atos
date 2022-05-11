using AutoMapper;
using Avaliacao_Atos.Application.Interfaces;
using Avaliacao_Atos.Application.ViewModels;
using Avaliacao_Atos.Domain.Entites;
using Avaliacao_Atos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
                throw new Exception("O id informado não é válido");

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
            User user = mapper.Map<User>(userViewModel);

            userRepository.Create(user);

            return true;
        }

        public bool Put(UserViewModel userViewModel)
        {
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
    }
}

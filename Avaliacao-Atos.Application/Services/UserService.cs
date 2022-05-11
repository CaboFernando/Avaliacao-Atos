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
    }
}

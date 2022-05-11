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

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            IEnumerable<User> users = userRepository.GetAll();

            foreach (var item in users)
            {
                userViewModels.Add(
                    new UserViewModel { 
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email
                    });
            }

            return userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = userViewModel.Email,
                Name = userViewModel.Name
            };

            userRepository.Create(user);

            return true;
        }
    }
}

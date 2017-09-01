using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services;
using PortfolioManagerClient.ProxyCloud.BLL.Mappers;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies.IRepositories;
using System;
using System.Collections.Generic;

namespace PortfolioManagerClient.ProxyCloud.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow, IUserRepository userManager)
        {
            _uow = uow;
            _userRepository = userManager;
        }

        public void Create(BllUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Create(user.ToDalUser());
            _uow.Commit();
        }

        public IEnumerable<BllUser> GetAll()
        {
            return _userRepository.GetAll()?.ToBllUserEnumerable();
        }

        public BllUser GetUserById(int id)
        {
            if (id < 0)
                throw new ArgumentException($"Argument '{nameof(id)}' can't be < 0");

            return _userRepository.GetById(id)?.ToBllUser();
        }

        public BllUser GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException($"Argument '{nameof(userName)}' can't be null or empty");

            return _userRepository.GetByName(userName)?.ToBllUser();
        }
    }
}

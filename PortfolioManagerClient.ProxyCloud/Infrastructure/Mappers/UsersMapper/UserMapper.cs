using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.Infrastructure.Mappers.UsersMapper
{
    public static class UserMapper
    {
        public static BllUser UserToBllUser(this UserViewModel userViewModel)
        {
            return new BllUser()
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name
            };
        }

        public static UserViewModel BllUserToUser(this BllUser bllUser)
        {
            return new UserViewModel()
            {
                Id = bllUser.Id,
                Name = bllUser.Name
            };
        }

        public static IList<UserViewModel> ToUserViewModelList(this IEnumerable<BllUser> bllUsers)
        {
            return bllUsers?.Select(x => x.BllUserToUser()) as IList<UserViewModel>;
        }

        public static IEnumerable<BllUser> ToBllUserEnumerable(this IList<UserViewModel> dbUsers)
        {
            return dbUsers?.Select(x => x.UserToBllUser());
        }
    }
}
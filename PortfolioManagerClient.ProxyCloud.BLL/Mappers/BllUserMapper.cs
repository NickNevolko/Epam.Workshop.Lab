using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.DAL.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.BLL.Mappers
{
    public static class BllUserMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            return new BllUser()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Shares = dalUser.Shares.ToBllShareEnumerable()
            };
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            return new DalUser()
            {
                Id = bllUser.Id,
                Name = bllUser.Name,
                Shares = bllUser.Shares.ToDalShareEnumerable()
            };
        }

        public static IEnumerable<BllUser> ToBllUserEnumerable(this IEnumerable<DalUser> dalUsers)
        {
            return dalUsers?.Select(x => x.ToBllUser());
        }

        public static IEnumerable<DalUser> ToDalUserEnumerable(this IEnumerable<BllUser> bllUsers)
        {
            return bllUsers?.Select(x => x.ToDalUser());
        }
    }
}

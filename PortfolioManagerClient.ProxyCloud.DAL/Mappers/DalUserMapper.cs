using PortfolioManagerClient.ProxyCloud.DAL.DTO;
using PortfolioManagerClient.ProxyCloud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PortfolioManagerClient.ProxyCloud.DAL.Mappers
{
    public static class DalUserMapper
    {
        public static DalUser ToDalUser(this DbUser dbUser)
        {
            return new DalUser()
            {
                Id = dbUser.Id,
                Name = dbUser.Name,
                Shares = dbUser.Shares.ToDalShareEnumerable()
            };
        }

        public static DbUser ToDbUser(this DalUser dalUser)
        {
            return new DbUser()
            {
                Id = dalUser.Id,
                Name = dalUser.Name,
                Shares = dalUser.Shares.ToDbShareCollection()
            };
        }

        public static IEnumerable<DalUser> ToDalUserEnumerable(this ICollection<DbUser> dbUsers)
        {
            return dbUsers?.Select(x => x.ToDalUser());
        }

        public static ICollection<DbUser> ToDbUserCollection(this IEnumerable<DalUser> dalUsers)
        {
            return dalUsers?.Select(x => x.ToDbUser()) as ICollection<DbUser>;
        }

        public static Expression<Func<DbUser, DalUser>> ExpressionToDalUser
        {
            get
            {
                return (DbUser user) => new DalUser()
                {
                    Id = user.Id,
                    Shares = user.Shares.ToDalShareEnumerable()
                };
            }
        }
    }
}

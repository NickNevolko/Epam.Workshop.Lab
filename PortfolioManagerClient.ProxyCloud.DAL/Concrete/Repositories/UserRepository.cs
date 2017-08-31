using PortfolioManagerClient.ProxyCloud.DAL.DTO;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies.IRepositories;
using PortfolioManagerClient.ProxyCloud.DAL.Mappers;
using PortfolioManagerClient.ProxyCloud.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        public static readonly string DefaultRole = "Default";

        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalUser item)
        {
            _context.Set<DbUser>().Add(item.ToDbUser());
        }

        public void Update(DalUser item)
        {
            _context.Set<DbUser>().AddOrUpdate(item.ToDbUser());
        }

        public void Delete(DalUser item)
        {
            var user = _context.Set<DbUser>().SingleOrDefault(u => u.Id == item.Id);
            if (user == null)
                throw new ArgumentException("Such user id was not found");

            _context.Set<DbUser>().Remove(user);
        }

        public DalUser GetById(int uniqueId)
        {
            var user = _context.Set<DbUser>().SingleOrDefault(u => u.Id == uniqueId);
            if (user == null)
                return null;

            return user.ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<DbUser>().Select(DalUserMapper.ExpressionToDalUser);
        }
    }
}

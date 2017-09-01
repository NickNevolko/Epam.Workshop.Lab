using PortfolioManagerClient.ProxyCloud.DAL.DTO;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies.IRepositories;
using PortfolioManagerClient.ProxyCloud.DAL.Mappers;
using PortfolioManagerClient.ProxyCloud.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PortfolioManagerClient.ProxyCloud.DAL.Concrete.Repositories
{
    public class ShareRepository : IShareRepository
    {
        private readonly DbContext _context;

        public ShareRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalShare item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var share = new DbShare()
            {
                Id = item.Id,
                User = item.User.ToDbUser(),
                SharesNumber = item.SharesNumber,
                Symbol = item.Symbol
            };

            _context.Set<DbShare>().Add(share);
        }

        public void Update(DalShare item)
        {
            var share = _context.Set<DbShare>().SingleOrDefault(u => u.Id == item.Id);
            if (share == null)
                throw new ArgumentException("Such id was not found");

            _context.Set<DbShare>().Remove(share);
            _context.Set<DbShare>().Add(item.ToDbShare());
        }

        public void Delete(DalShare item)
        {
            var share = _context.Set<DbShare>().SingleOrDefault(u => u.Id == item.Id);
            if (share == null)
                throw new ArgumentException("Such id was not found");

            _context.Set<DbShare>().Remove(share);
        }

        public DalShare GetById(int uniqueId)
        {
            var share = _context.Set<DbShare>().SingleOrDefault(u => u.Id == uniqueId);
            if (share == null)
                return null;

            return share.ToDalShare();
        }

        public IEnumerable<DalShare> GetAll()
        {
            return _context.Set<DbShare>().ToList().ToDalShareEnumerable();
        }
    }
}

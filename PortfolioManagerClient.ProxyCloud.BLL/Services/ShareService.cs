using PortfolioManagerClient.ProxyCloud.BLL.Entities;
using PortfolioManagerClient.ProxyCloud.BLL.Interfacies.Services;
using PortfolioManagerClient.ProxyCloud.BLL.Mappers;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies;
using PortfolioManagerClient.ProxyCloud.DAL.Interfacies.IRepositories;
using System;

namespace PortfolioManagerClient.ProxyCloud.BLL.Services
{
    public class ShareService : IShareService
    {
        private readonly IUnitOfWork _uow;
        private readonly IShareRepository _shareRepository;

        public ShareService(IUnitOfWork uow, IShareRepository taskManager)
        {
            _uow = uow;
            _shareRepository = taskManager;
        }

        public void Create(BllShare share)
        {
            if (share == null)
                throw new ArgumentNullException(nameof(share));

            _shareRepository.Create(share.ToDalShare());
            _uow.Commit();
        }
    }
}

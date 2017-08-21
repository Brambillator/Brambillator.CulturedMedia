using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.Infrastructure.Domain.Repositories;

namespace Brambillator.CulturedMedia.Domain.UnitOfWork
{
    public interface ICulturedMediaUnitOfWork
    {
        IRepository<ResourceModel> Resources { get; }
        void Commit();
    }
}

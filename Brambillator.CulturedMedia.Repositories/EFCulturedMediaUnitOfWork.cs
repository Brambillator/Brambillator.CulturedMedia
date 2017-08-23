using Microsoft.Extensions;
using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.CulturedMedia.Domain.UnitOfWork;
using Brambillator.Infrastructure.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brambillator.CulturedMedia.Repositories.EF
{
    public class EFCulturedMediaUnitOfWork : DbContext, ICulturedMediaUnitOfWork
    {
        private readonly EfRepository<ResourceModel> resourceRepository;

        private DbSet<ResourceModel> ResourceSet { get; set; }

        /// <summary>
        /// Initializes a new instance of Unit of Work for EntityFramework.
        /// If connectionString is not supplied will try to use LocalDB with DataBase "CulturedMedia".
        /// </summary>
        public EFCulturedMediaUnitOfWork(DbContextOptions options) : base(options)
        {
            resourceRepository = new EfRepository<ResourceModel>(ResourceSet);
        }

        /// <summary>
        /// Initializes a new instance of Unit of Work for EntityFramework with given connectionString
        /// </summary>
        /// <param name="connectionString">Data source Connection String</param>
        public EFCulturedMediaUnitOfWork(string connectionString)
        {
            resourceRepository = new EfRepository<ResourceModel>(ResourceSet);
        }

        public IRepository<ResourceModel> Resources
        {
            get
            {
                return resourceRepository;
            }
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}

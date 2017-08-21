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
        private readonly string connectionStr;

        private DbSet<ResourceModel> ResourceSet { get; set; }

        /// <summary>
        /// Initializes a new instance of Unit of Work for EntityFramework.
        /// If connectionString is not supplied will try to use LocalDB with DataBase "CulturedMedia".
        /// </summary>
        public EFCulturedMediaUnitOfWork()
        {
            connectionStr = @"Server=(localdb)\MSSQLLocalDB;Database=CulturedMedia;Trusted_Connection=True;";
            resourceRepository = new EfRepository<ResourceModel>(ResourceSet);
        }

        /// <summary>
        /// Initializes a new instance of Unit of Work for EntityFramework with given connectionString
        /// </summary>
        /// <param name="connectionString">Data source Connection String</param>
        public EFCulturedMediaUnitOfWork(string connectionString)
        {
            connectionStr = connectionString;
            resourceRepository = new EfRepository<ResourceModel>(ResourceSet);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceModel>().ToTable("Resources");
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

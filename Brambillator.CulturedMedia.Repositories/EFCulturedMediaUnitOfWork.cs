using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.CulturedMedia.Domain.UnitOfWork;
using Brambillator.Infrastructure.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brambillator.CulturedMedia.Repositories.EF
{
    public class EFCulturedMediaUnitOfWork : DbContext, ICulturedMediaUnitOfWork
    {
        private readonly EfRepository<CultureModel> cultureRepository;
        private readonly EfRepository<ResourceModel> resourceRepository;

        private DbSet<CultureModel> CultureSet { get; set; }
        private DbSet<ResourceModel> ResourceSet { get; set; }

        public EFCulturedMediaUnitOfWork()
        {
            cultureRepository = new EfRepository<CultureModel>(CultureSet);
            resourceRepository = new EfRepository<ResourceModel>(ResourceSet);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Make provider configurable
            // 
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CulturedMedia;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CultureModel>().ToTable("Cultures");
            modelBuilder.Entity<ResourceModel>().ToTable("Resources");
        }

        public IRepository<CultureModel> Cultures
        {
            get
            {
                return cultureRepository;
            }
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

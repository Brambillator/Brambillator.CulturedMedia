using Brambillator.CulturedMedia.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Brambillator.CulturedMedia.Domain.Models;
using Brambillator.Infrastructure.Domain.Repositories;

namespace Brambillator.CulturedMedia.Repositories.EF
{
    public class EFCultureMediaUnitOfWork : DbContext, ICulturedMediaUnitOfWork
    {
        private readonly EfRepository<CultureModel> cultureRepository;
        private readonly EfRepository<ResourceModel> resourceRepository;

        public DbSet<CultureModel> CultureSet { get; set; }
        public DbSet<ResourceModel> ResourceSet { get; set; }

        public EFCultureMediaUnitOfWork()
        {
            cultureRepository = new EfRepository<CultureModel>(CultureSet);
            resourceRepository = new EfRepository<ResourceModel>(ResourceSet);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Make provider configurable
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CulturedMedia;Trusted_Connection=True;");
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

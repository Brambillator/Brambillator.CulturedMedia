using Brambillator.CulturedMedia.Domain.Views;
using Brambillator.CulturedMedia.Repositories.EF;
using Brambillator.CulturedMedia.Service;
using Xunit;

namespace Brambillator.CulturedMedia.Tests
{
    public class ResourceTestForEFRepo
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CulturedMediaTestDB;Trusted_Connection=True;";

        public ResourceTestForEFRepo()
        {
            Repositories.EFCulturedMediaUnitOfWorkInitializer.Initialize(new EFCulturedMediaUnitOfWork(connectionString), true);
        }

        [Fact]
        public void ResourceTestForEFRepo_AddAndGet()
        {
            ResourceService service = new ResourceService(new EFCulturedMediaUnitOfWork(connectionString));

            service.AddTextResource("en-US", "BALL", "Bola", "Bola");
            service.AddTextResource("pt-BR", "BALL", "Ball", "Ball");

            service.UnitOfWork.Commit();

            Resource resBall = service.GetResource("pt-BR", "BALL");
            
            Assert.NotNull(resBall);
            Assert.Equal(resBall.Text, "Ball");

            service.UnitOfWork.Commit();
        }

        [Fact]
        public void ResourceTestForEFRepo_GetResource()
        {
            ResourceService service = new ResourceService(new EFCulturedMediaUnitOfWork(connectionString));

            service.AddTextResource("en-US", "ResourceTestForEFRepo_GetResource", "Test", "Test Method");

            service.UnitOfWork.Commit();

            Resource existent = service.GetResource("en-US", "ResourceTestForEFRepo_GetResource");
            Assert.Equal(existent.Text, "Test Method");

            Resource inexistent = service.GetResource("en-US", "___INEXISTENT_KEY___");
            Assert.Null(inexistent);

        }
    }
}

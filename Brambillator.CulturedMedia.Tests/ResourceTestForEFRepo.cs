using Brambillator.CulturedMedia.Domain.Views;
using Brambillator.CulturedMedia.Repositories.EF;
using Brambillator.CulturedMedia.Service;
using Xunit;

namespace Brambillator.CulturedMedia.Tests
{
    public class ResourceTestForEFRepo
    {
        [Fact]
        public void ResourceTestForEFRepo_AddAndGet()
        {
            ResourceService service = new ResourceService();
            service.UnitOfWork = new EFCultureMediaUnitOfWork();

            service.AddTextResource("en-US", "BALL", "Bola", "Bola");
            service.AddTextResource("pt-BR", "BALL", "Ball", "Ball");

            service.UnitOfWork.Commit();

            Resource resBall = service.GetResource("pt-BR", "BALL");
            
            Assert.NotNull(resBall);
            Assert.Equal(resBall.Text, "Ball");

            service.RemoveResourceForAllCultures("BALL");
            service.UnitOfWork.Commit();
        }
    }
}

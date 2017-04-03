using Brambillator.CulturedMedia.Repositories.EF;

namespace Brambillator.CulturedMedia.Repositories
{
    public static class EFCulturedMediaUnitOfWorkInitializer
    {
        public static void Initialize(EFCulturedMediaUnitOfWork context)
        {
            context.Database.EnsureCreated();
        }
    }
}

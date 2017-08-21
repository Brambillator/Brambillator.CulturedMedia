using Brambillator.CulturedMedia.Repositories.EF;

namespace Brambillator.CulturedMedia.Repositories
{
    public static class EFCulturedMediaUnitOfWorkInitializer
    {
        public static void Initialize(EFCulturedMediaUnitOfWork context, bool createNew)
        {
            if (createNew)
                context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }
    }
}

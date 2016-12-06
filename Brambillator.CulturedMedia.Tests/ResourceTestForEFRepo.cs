using Brambillator.CulturedMedia.Repositories.EF;
using Brambillator.CulturedMedia.Service;
using System;
using Xunit;

namespace Brambillator.CulturedMedia.Tests
{
    public class ResourceTestForEFRepo
    {
        [Fact]
        public void ResourceTestForEFRepo_AddAndGet()
        {
            ResourceService service = new ResourceService();
            //service.UnitOfWork = new EFCultureMediaUnitOfWork();
        }
    }
}

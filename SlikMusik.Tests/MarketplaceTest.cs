using NMock;
using NUnit.Framework;
using SlikMusik.Domain;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class MarketplaceTest
    {
        readonly MockFactory factory = new MockFactory();

        [TearDown]
        public void Cleanup()
        {
            factory.VerifyAllExpectationsHaveBeenMet();
            factory.ClearExpectations();
        }

        [Test]
        public void OpensUpAStore()
        {
            var store = new Store();
            var storeRegistry = factory.CreateMock<StoreRegistry>();
            var marketplace = new Marketplace(storeRegistry.MockObject);

            storeRegistry.Expects.One.MethodWith(_ => _.Add(store));

            marketplace.OpenUp(store);
        }
    }
}

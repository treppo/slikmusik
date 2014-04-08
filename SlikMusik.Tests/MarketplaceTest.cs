using NMock;
using NUnit.Framework;
using SlikMusik.Domain;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class MarketplaceTest
    {
        readonly MockFactory factory = new MockFactory();
        private Marketplace marketplace;
        private Mock<StoreRegistry> storeRegistry;
        private Store store;

        [SetUp]
        public void Setup()
        {
            store = new Store();
            storeRegistry = factory.CreateMock<StoreRegistry>();
            marketplace = new Marketplace(storeRegistry.MockObject);
        }

        [TearDown]
        public void Cleanup()
        {
            factory.VerifyAllExpectationsHaveBeenMet();
            factory.ClearExpectations();
        }

        [Test]
        public void OpensUpAStore()
        {
            storeRegistry.Expects.One.MethodWith(_ => _.Add(store));

            marketplace.OpenUp(store);
        }

        [Test]
        public void VisitStore()
        {
            int id = 1;
            store.Id = id;
            storeRegistry.Expects.One.MethodWith(_ => _.Visit(id)).Will(Return.Value(store));

            var s = marketplace.Visit(id);

            Assert.AreEqual(store, s);
        }
    }
}

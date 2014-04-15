using NMock;
using NUnit.Framework;
using SlikMusik.Domain;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class StoreInventoryTest
    {
        private StoreInventory storeInventory;
        private readonly MockFactory factory = new MockFactory();
        private Mock<StoreRegistry> mock;

        [SetUp]
        public void Setup()
        {
            mock = factory.CreateMock<StoreRegistry>();
            storeInventory = new StoreInventory(mock.MockObject);
        }

        [TearDown]
        public void Cleanup()
        {
            factory.VerifyAllExpectationsHaveBeenMet();
            factory.ClearExpectations();
        }

        [Test]
        public void AddMerchandize()
        {
            var store = new Store();
            var merch = BuildMerch(store);

            mock.Expects.One.MethodWith(_ => _.FindStore(store.Id)).WillReturn(store);
            mock.Expects.One.MethodWith(_ => _.Change(store));

            storeInventory.Add(merch);

            Assert.Contains(merch, store.Merchandize);
        }

        private Merchandize BuildMerch(Store store)
        {
            var merch = new Merchandize();
            merch.StoreId = store.Id;
            merch.Name = "Foo";
            return merch;
        }
    }
}

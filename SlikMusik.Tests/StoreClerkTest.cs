using NMock;
using NUnit.Framework;
using SlikMusik.Domain;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class StoreClerkTest
    {
        private StoreClerk storeClerk;
        private readonly MockFactory factory = new MockFactory();
        private Mock<StoreRegistry> mock;
        private Mock<Inventory> inventoryMock;
        private const int StoreId = 1;
        private const int MerchandizeId = 1;

        [SetUp]
        public void Setup()
        {
            mock = factory.CreateMock<StoreRegistry>();
            inventoryMock = factory.CreateMock<Inventory>();
            storeClerk = new StoreClerk(inventoryMock.MockObject);
        }

        [TearDown]
        public void Cleanup()
        {
            factory.VerifyAllExpectationsHaveBeenMet();
            factory.ClearExpectations();
        }

        [Test]
        public void AddsMerchandizeToInventory()
        {
            var store = BuildStore();
            var merch = BuildMerch(store);

            inventoryMock.Expects.One.MethodWith(_ => _.Add(merch));

            storeClerk.AddToInventory(merch);
        }

        [Test]
        public void GetsMerchandizeById()
        {
            var store = BuildStore();
            var merch = BuildMerch(store);

            inventoryMock.Expects.One.MethodWith(_ => _.Retrieve(merch.Id)).WillReturn(merch);

            var foundMerch = storeClerk.GetMerchandize(merch.Id);

            Assert.AreEqual(merch, foundMerch);
        }

        [Test]
        public void AddsMerchandizeToShoppingCart()
        {
        }

        private static Store BuildStore()
        {
            var store = new Store {Id = StoreId};
            return store;
        }

        private static Merchandize BuildMerch(Store store)
        {
            var merch = new Merchandize {Id = MerchandizeId, StoreId = store.Id, Name = "Foo"};
            return merch;
        }
    }
}
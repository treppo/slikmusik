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
        private int STORE_ID = 1;
        private int MERCHANDIZE_ID = 1;

        [SetUp]
        public void Setup()
        {
            mock = factory.CreateMock<StoreRegistry>();
            storeClerk = new StoreClerk(mock.MockObject);
        }

        [TearDown]
        public void Cleanup()
        {
            factory.VerifyAllExpectationsHaveBeenMet();
            factory.ClearExpectations();
        }

        [Test]
        public void AddsMerchandizeToStore()
        {
            var store = BuildStore();
            var merch = BuildMerch(store);

            mock.Expects.One.MethodWith(_ => _.FindStore(store.Id)).WillReturn(store);
            mock.Expects.One.MethodWith(_ => _.Change(store));

            storeClerk.Add(merch);

            Assert.Contains(merch, store.Merchandize);
        }

        [Test]
        public void GetsMerchandizeById()
        {
            var store = BuildStore();
            var merch = BuildMerch(store);
            store.Merchandize.Add(merch);

            mock.Expects.One.MethodWith(_ => _.FindStore(store.Id)).WillReturn(store);

            var foundMerch = storeClerk.GetMerchandize(STORE_ID, MERCHANDIZE_ID);
            
            Assert.AreEqual(merch, foundMerch);
        }

        private Store BuildStore()
        {
            var store = new Store();
            store.Id = STORE_ID;
            return store;
        }

        private Merchandize BuildMerch(Store store)
        {
            var merch = new Merchandize();
            merch.Id = MERCHANDIZE_ID;
            merch.StoreId = store.Id;
            merch.Name = "Foo";
            return merch;
        }
    }
}

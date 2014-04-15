using System.Linq;
using NUnit.Framework;
using SlikMusik.Domain;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class EfStoreRegistryTest
    {
        private StoreRegistry storeRegistry;
        private EfDbContext context;

        [SetUp]
        public void Setup()
        {
            context = new EfDbContext(Effort.DbConnectionFactory.CreateTransient());
            storeRegistry = new EfStoreRegistry(context);
        }

        [TearDown]
        public void Cleanup()
        {

        }

        [Test]
        public void OpenUpAStore()
        {
            var store =  BuildStore();

            Assert.Contains(store, context.Stores.ToList());
        }

        [Test]
        public void FindAStore()
        {
            var store = BuildStore();

            var s = storeRegistry.FindStore(1);

            Assert.AreEqual(store, s);
        }

        [Test]
        public void ListAllStores()
        {
            var store = BuildStore();
            var store2 = BuildStore();

            var set = storeRegistry.ListAllStores();

            Assert.Contains(store, set.ToList());
            Assert.Contains(store2, set.ToList());
        }

        [Test]
        public void ChangeAStore()
        {
            var store = BuildStore();
            store.Name = "Bar";

            storeRegistry.Change(store);

            Assert.AreEqual("Bar", storeRegistry.FindStore(1).Name);
        }

        [Test]
        public void AddMerchandize()
        {
            var store = BuildStore();
            var merch = BuildMerch(store);

            storeRegistry.AddToStore(merch);

            Assert.Contains(merch, storeRegistry.FindStore(store.Id).Merchandize);
        }

        private Merchandize BuildMerch(Store store)
        {
            var merch = new Merchandize();
            merch.StoreId = store.Id;
            merch.Name = "Foo";
            return merch;
        }

        private Store BuildStore()
        {
            var store = new Store();
            store.Id = 1;
            store.Name = "Foo";
            storeRegistry.OpenUp(store);
            return store;
        }
    }
}

using System.Collections;
using NUnit.Framework;
using SlikMusik.Core;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class StoreRegistryTest
    {
        private StoreRegistry storeRegistry;
        private EfDbContext context;

        [SetUp]
        public void Setup()
        {
            context = new EfDbContext(Effort.DbConnectionFactory.CreateTransient());
            storeRegistry = new EfStoreRegistry(context);
        }

        [Test]
        public void OpenUpAndFindAStore()
        {
            var store = OpenUpStore();
            var found = storeRegistry.FindStore(1);

            Assert.AreEqual(store, found);
        }

        [Test]
        public void ListAllStores()
        {
            var store = OpenUpStore();
            var store2 = OpenUpStore();

            var set = storeRegistry.ListAllStores();

            Assert.Contains(store, (ICollection) set);
            Assert.Contains(store2, (ICollection) set);
        }

        [Test]
        public void ChangeAStore()
        {
            var store = OpenUpStore();
            store.Name = "Bar";

            storeRegistry.Change(store);

            Assert.AreEqual("Bar", storeRegistry.FindStore(1).Name);
        }

        private Store OpenUpStore()
        {
            var store = new Store {Id = 1, Name = "Foo"};
            storeRegistry.OpenUp(store);
            return store;
        }
    }
}
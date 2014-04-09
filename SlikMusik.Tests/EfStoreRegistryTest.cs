using System.Linq;
using NUnit.Framework;
using SlikMusik.Domain;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class EfStoreRegistryTest
    {
        private StoreRegistry storeRegistry;
        readonly EfDbContext context = new EfDbContext(Effort.DbConnectionFactory.CreateTransient());

        [SetUp]
        public void Setup()
        {
            storeRegistry = new EfStoreRegistry(context);
        }

        [TearDown]
        public void Cleanup()
        {

        }

        [Test]
        public void OpenUpAStore()
        {
            var store = new Store();
            storeRegistry.OpenUp(store);

            Assert.Contains(store, context.Stores.ToList());
        }

        [Test]
        public void FindAStore()
        {
            var store = new Store();
            store.Id = 1;
            storeRegistry.OpenUp(store);;

            var s = storeRegistry.FindStore(1);

            Assert.AreEqual(store, s);
        }

        [Test]
        public void ListAllStores()
        {
            var store = new Store();
            var store2 = new Store();
            storeRegistry.OpenUp(store);
            storeRegistry.OpenUp(store2);

            var set = storeRegistry.ListAllStores();

            Assert.Contains(store, set.ToList());
            Assert.Contains(store2, set.ToList());
        }
    }
}

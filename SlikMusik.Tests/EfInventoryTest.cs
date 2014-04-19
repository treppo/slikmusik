using NUnit.Framework;
using SlikMusik.Core;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class EfInventoryTest
    {
        private Inventory inventory;
        private EfDbContext context;

        [SetUp]
        public void Setup()
        {
            context = new EfDbContext(Effort.DbConnectionFactory.CreateTransient());
            inventory = new EfInventory(context);
        }

        [Test]
        public void AddsAndRetrievesMerchandize()
        {
            var store = new Store {Id = 1};
            var merch = new Merchandize {Id = 1, Store = store};

            inventory.Add(merch);
            var retrieved = inventory.Retrieve(merch.Id);

            Assert.AreEqual(merch, retrieved);
        }
    }
}
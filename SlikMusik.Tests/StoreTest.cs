using NUnit.Framework;
using SlikMusik.Core;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class StoreTest
    {
        [Test]
        public void KnowsInventorySize()
        {
            var store = new Store();
            store.Inventory.Add(new Merchandize());

            var size = store.InventorySize;

            Assert.AreEqual(1, size);
        }

        [Test]
        public void HasOwner()
        {
            var store = new Store {UserId = "1"};

            Assert.IsTrue(store.HasOwner("1"));
            Assert.IsFalse(store.HasOwner("2"));
        }
    }
}
using NUnit.Framework;
using SlikMusik.Domain;

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
    }
}
using NMock;
using NUnit.Framework;
using SlikMusik.Domain.Entities;
using SlikMusik.Domain.Interfaces;

namespace SlikMusik.Tests.Entities
{

    [TestFixture]
    public class StoreTest
    {
        private readonly MockFactory _factory = new MockFactory();

        [Test]
        public void OfferMerchandize()
        {
            var store = new Store();
            var merch1 = _factory.CreateInstance<Merchandize>();

            store.OfferMerchandize(merch1);

            Assert.Contains(merch1, store.AvailableMerchandize);
        }
    }
}
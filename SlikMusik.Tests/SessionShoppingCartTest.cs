using System.Linq;
using NUnit.Framework;
using SlikMusik.Core;

namespace SlikMusik.Tests
{
    [TestFixture]
    public class SessionShoppingCartTest
    {
        [Test]
        public void GetsInstanceFromSession()
        {
            var cart = new SessionShoppingCart();

            var retrieved = SessionShoppingCart.From(cart);

            Assert.AreEqual(cart, retrieved);
        }

        [Test]
        public void CreatesFirstInstance()
        {
            var retrieved = SessionShoppingCart.From(null);

            Assert.IsInstanceOf<SessionShoppingCart>(retrieved);
        }

        [Test]
        public void KeepsABunchOfMerchandize()
        {
            var merch1 = new Merchandize();
            var merch2 = new Merchandize();
            var cart = new SessionShoppingCart();

            cart.Add(merch1);
            cart.Add(merch2);

            Assert.Contains(merch1, cart.Content.ToList());
            Assert.Contains(merch2, cart.Content.ToList());
        }
    }
}
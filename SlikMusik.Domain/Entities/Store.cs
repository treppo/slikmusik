using System.Collections;
using SlikMusik.Domain.Interfaces;

namespace SlikMusik.Domain.Entities
{
    public class Store
    {
        private IList _inventory = new ArrayList();

        public void OfferMerchandize(Merchandize merch)
        {
            _inventory.Add(merch);
        }

        public ICollection AvailableMerchandize
        {
            get { return _inventory; }
        }

        public string Name { get; set; }
    }
}

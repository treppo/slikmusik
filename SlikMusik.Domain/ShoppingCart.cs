using System.Collections.Generic;

namespace SlikMusik.Domain
{
    public interface ShoppingCart
    {
        void Add(Merchandize merch);
        IEnumerable<Merchandize> Content { get; }
    }
}

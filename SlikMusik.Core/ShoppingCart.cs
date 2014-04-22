using System.Collections.Generic;

namespace SlikMusik.Core
{
    public interface ShoppingCart
    {
        void Add(Merchandize merch);
        IEnumerable<Merchandize> Content { get; }
        void Remove(int id);
    }
}

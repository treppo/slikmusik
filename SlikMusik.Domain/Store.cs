
using System.Collections.Generic;

namespace SlikMusik.Domain
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Merchandize> Merchandizes { get; set; }

        public Store()
        {
            Merchandizes = new List<Merchandize>();
        }
    }
}

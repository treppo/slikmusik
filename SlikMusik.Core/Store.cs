using System.Collections.Generic;

namespace SlikMusik.Core
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Merchandize> Inventory { get; set; }

        public int InventorySize
        {
            get { return Inventory.Count; }
        }

        public Store()
        {
            Inventory = new List<Merchandize>();
        }
    }
}
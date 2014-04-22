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

        public string UserId { get; set; }

        public Store()
        {
            Inventory = new List<Merchandize>();
        }

        public bool HasOwner(string userId)
        {
            return UserId == userId;
        }
    }
}
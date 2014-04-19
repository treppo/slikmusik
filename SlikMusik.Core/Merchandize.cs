namespace SlikMusik.Core
{
    public class Merchandize
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public string Name { get; set; }
    }
}

namespace WarehouseSystem.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Voorraad { get; set; }
        public int MagazijnId { get; set; }
    }
}

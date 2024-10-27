namespace BrightFocus.Core.Domain
{
    public class Product : MEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceUnit { get; set; }
    }
}

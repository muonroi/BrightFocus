namespace BrightFocus.Core.Models.Warehouse
{
    public class UpdateWarehouseRequest
    {
        public Guid EntityId { get; set; }
        public double Volume { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}

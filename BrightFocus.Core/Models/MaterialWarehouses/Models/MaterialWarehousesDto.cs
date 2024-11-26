namespace BrightFocus.Core.Models.MaterialWarehouses.Models;

public class MaterialWarehousesDto : IMapFrom<MaterialWarehouseEntity>
{
    public Guid EntityId { get; set; }

    public string ProductCode { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public double Quantification { get; set; }

    public double Width { get; set; }

    public string Color { get; set; } = string.Empty;

    public string Characteristic { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public string Factory { get; set; } = string.Empty;

    public string Warehouse { get; set; } = string.Empty;
    public string ReceiptNumber { get; set; } = string.Empty;
    public MaterialProductType MaterialProductType { get; set; }
}

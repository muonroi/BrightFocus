namespace BrightFocus.Core.Models.MaterialWarehouses.Models;

public class MaterialWarehousesDto : IMapFrom<MaterialWarehouseEntity>
{
    public Guid EntityId { get; set; }

    public string ProductCode { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public double Quantification { get; set; }

    public string Color { get; set; } = string.Empty;

    public string Characteristic { get; set; } = string.Empty;

    public double Quantity { get; set; }

    public double Volume { get; set; }

    public string Warehouse { get; set; } = string.Empty;

    public string ReceiptNumber { get; set; } = string.Empty;

    public string FileNumber { get; set; } = string.Empty;

    public MaterialProductType MaterialProductType { get; set; }

    public string Note { get; set; } = string.Empty;

    public double Price { get; set; }

    public double Amount { get; set; }

    public DateTime CreatedDate { get; set; }
}

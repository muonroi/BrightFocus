namespace BrightFocus.Core.Models.MaterialWarehouses.Request;

public class CreateOrUpdateMaterialWarehousesRequest : IMapFrom<MaterialWarehouseEntity>
{
    public string ProductName { get; set; } = string.Empty;

    public string Material { get; set; } = string.Empty;

    public int Quantification { get; set; }


    public string UnitQuantification { get; set; } = string.Empty;

    public int Width { get; set; }

    public string UnitWidth { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string Characteristic { get; set; } = string.Empty;


    public int Quantity { get; set; }


    public string UnitQuantity { get; set; } = string.Empty;


    public string Factory { get; set; } = string.Empty;

    public string Warehouse { get; set; } = string.Empty;


    public string ReceiptNumber { get; set; } = string.Empty;

    public DateTime? EntryDate { get; set; }

    public string FileNumber { get; set; } = string.Empty;
}

namespace BrightFocus.Core.Domain;

[Table("InventoryItems")]
public class InventoryItem : MEntity
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Specification { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string Factory { get; set; } = string.Empty;
    public string Warehouse { get; set; } = string.Empty;
    public string ReceiptNumber { get; set; } = string.Empty;
    public DateTime? EntryDate { get; set; }
    public string FileNumber { get; set; } = string.Empty;
}

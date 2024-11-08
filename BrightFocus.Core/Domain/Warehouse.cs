namespace BrightFocus.Core.Domain
{
    [Table("warehouse")]
    public class Warehouse : MEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FactoryName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

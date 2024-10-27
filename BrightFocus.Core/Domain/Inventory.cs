namespace BrightFocus.Core.Domain
{
    public class Inventory : MEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseListCommand
{
    public class GetMaterialWarehouseListCommand : IRequest<MResponse<MPagedResult<MaterialWarehousesDto>>>
    {
        public int Page { get; set; }
        public string Search { get; set; } = string.Empty;
        public string SortBy { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
        public int? PageSize { get; set; }

        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Material { get; set; }
        public double? Quantification { get; set; }
        public double? Width { get; set; }
        public string? Color { get; set; }
        public string? Characteristic { get; set; }
        public double? Quantity { get; set; }
        public string? Warehouse { get; set; }

    }
}

namespace BrightFocus.Application.Query.MaterialWarehouse.GetMaterialWarehouseListCommand
{
    public class GetMaterialWarehouseListCommand : IRequest<MResponse<MPagedResult<MaterialWarehousesDto>>>
    {
        public int Page { get; set; }
        public string Search { get; set; } = string.Empty;
        public string SortBy { get; set; } = string.Empty;
        public string SortOrder { get; set; } = string.Empty;
        public int? PageSize { get; set; }

    }
}

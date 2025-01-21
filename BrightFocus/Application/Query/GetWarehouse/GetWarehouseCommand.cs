

namespace BrightFocus.Application.Query.GetWarehouse
{
    public class GetWarehouseCommand : IRequest<MResponse<MPagedResult<TaskMaterialResponse>>>
    {
        public int PageIndex { get; set; }

        public DateTime? SearchByDate { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string StructureName { get; set; } = string.Empty;

        public string IngredientName { get; set; } = string.Empty;

        public string CharacteristicName { get; set; } = string.Empty;
    }
}

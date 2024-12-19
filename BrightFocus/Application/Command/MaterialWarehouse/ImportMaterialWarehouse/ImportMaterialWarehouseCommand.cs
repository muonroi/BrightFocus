namespace BrightFocus.Application.Command.MaterialWarehouse.ImportMaterialWarehouse
{
    public class ImportMaterialWarehouseCommand
        : IRequest<MResponse<bool>>
    {
        public required IFormFile File { get; set; }
    }
}

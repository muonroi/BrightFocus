namespace BrightFocus.Application.Command.MaterialWarehouse.ImportMaterialWarehouse
{

    public class ImportMaterialWarehouseCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig), IRequestHandler<ImportMaterialWarehouseCommand, MResponse<bool>>
    {
        public async Task<MResponse<bool>> Handle(ImportMaterialWarehouseCommand request, CancellationToken cancellationToken)
        {
            MResponse<bool> result = new();
            List<CreateMaterialWarehouseCommand> materialWarehouseList = [];

            using (MemoryStream stream = new())
            {
                await request.File.CopyToAsync(stream, cancellationToken);

                using XLWorkbook workbook = new(stream);
                IXLWorksheet worksheet = workbook.Worksheet(1);
                IEnumerable<IXLRangeRow>? rows = worksheet.RangeUsed()?.RowsUsed().Skip(1);
                if (rows is null)
                {
                    result.StatusCode = StatusCodes.Status400BadRequest;
                    result.AddErrorMessage("File is null");
                    return result;
                }

                foreach (IXLRangeRow? row in rows)
                {
                    CreateMaterialWarehouseCommand command = new()
                    {
                        ProductCode = row.Cell(1).GetString().Trim(),
                        ProductName = row.Cell(2).GetString().Trim(),
                        Material = row.Cell(3).GetString().Trim(),
                        Quantification = double.TryParse(row.Cell(4).GetString(), out double quantification) ? quantification : 0,
                        Color = row.Cell(6).GetString().Trim(),
                        Characteristic = row.Cell(7).GetString().Trim(),
                        Quantity = double.TryParse(row.Cell(8).GetString(), out double quantity) ? quantity : 0,
                        Warehouse = row.Cell(10).GetString().Trim(),
                        ReceiptNumber = row.Cell(11).GetString().Trim(),
                        MaterialProductType = Enum.TryParse(row.Cell(13).GetString(), out MaterialProductType productType) ? productType : MaterialProductType.None
                    };

                    materialWarehouseList.Add(command);
                }
            }

            foreach (CreateMaterialWarehouseCommand command in materialWarehouseList)
            {
                MResponse<bool> createResult = await Mediator.Send(command, cancellationToken);
                if (!createResult.IsOK)
                {
                    return createResult;
                }
            }
            return result;

        }
    }
}

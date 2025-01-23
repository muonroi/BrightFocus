namespace BrightFocus.Application.Command.Task.ImportExportTask
{
    public class ImportExportTaskCommandValidator : AbstractValidator<ImportExportTaskCommand>
    {
        public ImportExportTaskCommandValidator()
        {
            _ = RuleFor(x => x.TaskName)
                .NotEmpty().WithMessage("Tên công việc không được để trống.");

            _ = RuleFor(x => x.Material)
                .NotEmpty().WithMessage("Nguyên liệu không được để trống.");

            _ = RuleFor(x => x.Source)
                .NotNull().WithMessage("Nguồn nhập xuất không được để trống.");

            _ = RuleFor(x => x.Employee)
                .NotEmpty().WithMessage("Tên nhân viên không được để trống.");

            _ = RuleFor(x => x.Factory)
                .NotEmpty().WithMessage("Nhà máy không được để trống.");

            _ = RuleFor(x => x.DeadlineDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Hạn chót phải lớn hơn thời điểm hiện tại.");

            _ = RuleForEach(x => x.ProductsImport)
                .SetValidator(new TaskMaterialRequestValidator());

            _ = RuleForEach(x => x.ProductsExport)
                           .SetValidator(new TaskMaterialRequestValidator())
                           .When(x => x.ProductsExport != null && x.ProductsExport.Exists(e => e != null), ApplyConditionTo.CurrentValidator);
        }
    }
}

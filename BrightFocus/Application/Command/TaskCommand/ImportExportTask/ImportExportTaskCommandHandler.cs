

namespace BrightFocus.Application.Command.TaskCommand.ImportExportTask
{
    public class ImportExportTaskCommandHandler(
        IMapper mapper,
        MAuthenticateInfoContext tokenInfo,
        IAuthenticateRepository authenticateRepository,
        Serilog.ILogger logger,
        IMediator mediator,
        MPaginationConfig paginationConfig,
        IImportRepository taskImportRepository,
        IExportRepository taskExportRepositor
    ) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
        IRequestHandler<ImportExportTaskCommand, MResponse<bool>>
    {
        public Task<MResponse<bool>> Handle(ImportExportTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

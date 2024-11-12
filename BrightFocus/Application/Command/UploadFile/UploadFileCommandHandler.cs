

namespace BrightFocus.Application.Command.UploadFile;

public class UploadFileCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, Serilog.ILogger logger, IMediator mediator, MPaginationConfig paginationConfig)
            : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig);

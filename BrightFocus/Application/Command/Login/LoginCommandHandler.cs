
namespace BrightFocus.Application.Command.Login
{
    public class LoginCommandHandler(
        IAuthenticateRepository authenticateRepository
        )
        : IRequestHandler<LoginCommand, MResponse<LoginResponseModel>>
    {
        public async Task<MResponse<LoginResponseModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            MResponse<LoginResponseModel> result = await authenticateRepository.Login(new LoginRequestModel
            {
                Username = request.Username,
                Password = request.Password
            }, cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}

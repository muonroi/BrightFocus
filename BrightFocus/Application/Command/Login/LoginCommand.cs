namespace BrightFocus.Application.Command.Login
{
    public class LoginCommand : IRequest<MResponse<LoginResponseModel>>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}





namespace BrightFocus.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion(0.9, Deprecated = true)]
    public class AuthController(BrightFocusDbContext dbContext,
        IUnitOfWork unitOfWork,
        MAuthenticateInfoContext infoContext,
        IAuthenticateRepository authenticateRepository) :
        MAuthControllerBase<Permission>(dbContext, infoContext, authenticateRepository)
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel command, CancellationToken cancellationToken)
        {
            MResponse<LoginResponseModel> result = await unitOfWork.AuthenticateRepository.Login(command, cancellationToken).ConfigureAwait(false);
            return result.GetActionResult();
        }

        [HttpPost("logout")]
        public override Task<IActionResult> Logout()
        {
            return base.Logout();
        }

        [HttpPost("register")]
        public override Task<IActionResult> Register([FromBody] RegisterRequestModel request, CancellationToken cancellationToken)
        {
            return base.Register(request, cancellationToken);
        }

        [HttpPost("create-role")]
        [Permission<Permission>(Permission.Auth_CreateRole)]
        public override Task<IActionResult> CreateRole([FromBody] CreateRoleRequestModel request)
        {
            return base.CreateRole(request);
        }

        [HttpPost("assign-permission")]
        [Permission<Permission>(Permission.Auth_AssignPermission)]
        public override Task<IActionResult> AssignPermissionToRole([FromBody] AssignPermissionRequestModel request)
        {
            return base.AssignPermissionToRole(request);
        }

        [HttpGet("user-permissions/{userId}")]
        [Permission<Permission>(Permission.Auth_GetPermissions)]
        public override Task<IActionResult> GetUserPermissions(Guid userId)
        {
            return base.GetUserPermissions(userId);
        }

        [HttpPost("update-role")]
        [Permission<Permission>(Permission.Auth_UpdateRole)]
        public override Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequestModel request)
        {
            return base.UpdateRole(request);
        }

        [HttpPost("assign-role")]
        [Permission<Permission>(Permission.Auth_AssignRoleUser)]
        public override Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleRequestModel request)
        {
            return base.AssignRoleToUser(request);
        }

        [HttpDelete("delete-role/{roleId}")]
        [Permission<Permission>(Permission.Auth_DeleteRole)]
        public override Task<IActionResult> DeleteRole(Guid roleId)
        {
            return base.DeleteRole(roleId);
        }

        [HttpGet("roles")]
        [Permission<Permission>(Permission.Auth_GetRoles)]
        public override Task<IActionResult> GetRoles()
        {
            return base.GetRoles();
        }

        [HttpGet("role-permissions/{roleId}")]
        [Permission<Permission>(Permission.Auth_GetRolePermissions)]
        public override Task<IActionResult> GetRolePermissions(Guid roleId)
        {
            return base.GetRolePermissions(roleId);
        }

        [HttpGet("role-users/{roleId}")]
        [Permission<Permission>(Permission.Auth_GetRoleUsers)]
        public override Task<IActionResult> GetRoleUsers(Guid roleId)
        {
            return base.GetRoleUsers(roleId);
        }

        [HttpDelete("remove-permission/{roleId}/{permissionId}")]
        [Permission<Permission>(Permission.Auth_RemovePermissionFromRole)]
        public override Task<IActionResult> RemovePermissionFromRole(Guid roleId, Guid permissionId)
        {
            return base.RemovePermissionFromRole(roleId, permissionId);
        }
    }
}





namespace BrightFocus.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion(0.9, Deprecated = true)]
    public class AuthController(BrightFocusDbContext dbContext, MAuthenticateTokenHelper<Permission> tokenHelper) : MAuthControllerBase<Permission>(dbContext, tokenHelper)
    {
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
        public override Task<IActionResult> GetUserPermissions(long userId)
        {
            return base.GetUserPermissions(userId);
        }

        [HttpPost("update-role")]
        [Permission<Permission>(Permission.Auth_UpdateRole)]
        public override Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequestModel request)
        {
            return base.UpdateRole(request);
        }

        [HttpDelete("delete-role/{roleId}")]
        [Permission<Permission>(Permission.Auth_DeleteRole)]
        public override Task<IActionResult> DeleteRole(long roleId)
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
    }
}

namespace BrightFocus.Data.Config.Enum
{
    [Flags]
    public enum Permission : long
    {
        None = 0,
        Auth_CreateRole = 1L << 0,         // 1
        Auth_UpdateRole = 1L << 1,         // 2
        Auth_DeleteRole = 1L << 2,         // 4
        Auth_GetRoles = 1L << 3,           // 8
        Auth_GetRoleById = 1L << 4,        // 16
        Auth_AssignPermission = 1L << 5,   // 32
        Auth_GetPermissions = 1L << 6,     // 64
        Auth_GetRolePermissions = 1L << 7, // 128
        Auth_GetRoleUsers = 1L << 8,       // 256
        Chemist_Create = 1L << 9,          // 512

        Auth_Admin = Auth_CreateRole | Auth_UpdateRole | Auth_DeleteRole | Auth_GetRoles | Auth_GetRoleById | Auth_AssignPermission | Auth_GetPermissions | Auth_GetRolePermissions | Auth_GetRoleUsers
    }
}

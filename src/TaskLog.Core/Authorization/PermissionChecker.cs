using Abp.Authorization;
using TaskLog.Authorization.Roles;
using TaskLog.Authorization.Users;

namespace TaskLog.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TaskLog.Authorization
{
    public class TaskLogAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_DailyWork, L("DailyWork"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TaskLogConsts.LocalizationSourceName);
        }
    }
}

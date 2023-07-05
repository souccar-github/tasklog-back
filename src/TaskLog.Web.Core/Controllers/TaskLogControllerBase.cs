using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TaskLog.Controllers
{
    public abstract class TaskLogControllerBase: AbpController
    {
        protected TaskLogControllerBase()
        {
            LocalizationSourceName = TaskLogConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskLog.EntityFrameworkCore;
using TaskLog.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TaskLog.Web.Tests
{
    [DependsOn(
        typeof(TaskLogWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TaskLogWebTestModule : AbpModule
    {
        public TaskLogWebTestModule(TaskLogEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskLogWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TaskLogWebMvcModule).Assembly);
        }
    }
}
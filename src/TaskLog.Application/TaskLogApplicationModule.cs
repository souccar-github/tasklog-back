using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskLog.Authorization;

namespace TaskLog
{
    [DependsOn(
        typeof(TaskLogCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TaskLogApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TaskLogAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TaskLogApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

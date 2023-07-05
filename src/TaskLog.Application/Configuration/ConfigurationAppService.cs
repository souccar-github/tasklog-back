using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TaskLog.Configuration.Dto;

namespace TaskLog.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TaskLogAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

using System.Threading.Tasks;
using TaskLog.Configuration.Dto;

namespace TaskLog.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

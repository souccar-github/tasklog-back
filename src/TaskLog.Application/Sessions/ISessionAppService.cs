using System.Threading.Tasks;
using Abp.Application.Services;
using TaskLog.Sessions.Dto;

namespace TaskLog.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

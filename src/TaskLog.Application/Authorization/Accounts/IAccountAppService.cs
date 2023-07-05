using System.Threading.Tasks;
using Abp.Application.Services;
using TaskLog.Authorization.Accounts.Dto;

namespace TaskLog.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

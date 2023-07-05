using Abp.Application.Services;
using TaskLog.MultiTenancy.Dto;

namespace TaskLog.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


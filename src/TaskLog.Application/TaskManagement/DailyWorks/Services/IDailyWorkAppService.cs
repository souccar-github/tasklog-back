using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.DailyWorks.Dto;
using TaskLog.TaskManagement.Phases.Dto;

namespace TaskLog.TaskManagement.DailyWorks.Services
{
    public interface IDailyWorkAppService : IApplicationService
    {
        PagedResultDto<DailyWorkDto> GetAll(PagedPhaseResultRequestDto input);
        Task<UpdateDailyWorkDto> GetForEditAsync(EntityDto input);
        Task<DailyWorkDto> GetAsync(EntityDto input);
        Task<DailyWorkDto> CreateAsync(CreateDailyWorkDto input);
        Task<DailyWorkDto> UpdateAsync(UpdateDailyWorkDto input);
        Task DeleteAsync(EntityDto input);
    }
}

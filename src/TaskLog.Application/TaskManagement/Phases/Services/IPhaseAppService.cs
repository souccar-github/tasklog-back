using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Phases.Dto;
using TaskLog.TaskManagement.Projects.Dto;
using TaskLog.TaskManagement.TaskLogs.Dto;

namespace TaskLog.TaskManagement.Phases.Services
{
    public interface IPhaseAppService : IApplicationService
    {
        PagedResultDto<PhaseDto> GetAll(PagedPhaseResultRequestDto input);
        Task<UpdatePhaseDto> GetForEditAsync(EntityDto input);
        Task<PhaseDto> GetAsync(EntityDto input);
        Task<PhaseDto> CreateAsync(CreatePhaseDto input);
        Task<PhaseDto> UpdateAsync(UpdatePhaseDto input);
        Task DeleteAsync(EntityDto input);
        Task CompletePhase(EntityDto input);

    }
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Phases.Dto;
using TaskLog.TaskManagement.TaskTypes.Dto;

namespace TaskLog.TaskManagement.TaskTypes.Services
{
    public interface ITaskTypeAppService : IApplicationService
    {
        PagedResultDto<TaskTypeDto> GetAll(PagedTaskTypeResultRequestDto input);
        Task<UpdateTaskTypeDto> GetForEditAsync(EntityDto input);
        Task<TaskTypeDto> GetAsync(EntityDto input);
        Task<TaskTypeDto> CreateAsync(CreateTaskTypeDto input);
        Task<TaskTypeDto> UpdateAsync(UpdateTaskTypeDto input);
        Task DeleteAsync(EntityDto input);
    }
}

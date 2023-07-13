using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Tasks.Dto;

namespace TaskLog.TaskManagement.Tasks.Services
{
    public interface ITaskAppService : IApplicationService
    {
        PagedResultDto<TaskDto> GetAll(PagedTaskResultRequestDto input);
        Task<UpdateTaskDto> GetForEditAsync(EntityDto input);
        Task<TaskDto> GetAsync(EntityDto input);
        Task<TaskDto> CreateAsync(CreateTaskDto input);
        Task<TaskDto> UpdateAsync(UpdateTaskDto input);
        System.Threading.Tasks.Task DeleteAsync(EntityDto input);
        Task<List<TaskDto>> GetCurrentUserTasks();
        System.Threading.Tasks.Task StartTask(EntityDto input);
        System.Threading.Tasks.Task CompleteTask(EntityDto input);
    }
}

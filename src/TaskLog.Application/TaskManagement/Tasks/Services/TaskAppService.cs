using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Phases.Dto;
using TaskLog.TaskManagement.Tasks.Dto;

namespace TaskLog.TaskManagement.Tasks.Services
{
    public class TaskAppService : TaskLogAppServiceBase, ITaskAppService
    {
        private readonly ITaskDomainService _taskDomainService;

        public TaskAppService(ITaskDomainService taskDomainService)
        {
            _taskDomainService = taskDomainService;
        }

        public async Task<TaskDto> CreateAsync(CreateTaskDto input)
        {
            return ObjectMapper.Map<TaskDto>(await _taskDomainService.Insert(ObjectMapper.Map<Task>(input)));
        }

        public async System.Threading.Tasks.Task DeleteAsync(EntityDto input)
        {
            await _taskDomainService.Delete(input.Id);
        }

        public PagedResultDto<TaskDto> GetAll(PagedTaskResultRequestDto input)
        {
            var tasks = _taskDomainService.GetForGrid(input.Keyword);
            tasks = tasks.Skip(input.SkipCount).Take(input.MaxResultCount);

            var list = ObjectMapper.Map<List<TaskDto>>(tasks.ToList());
            return new PagedResultDto<TaskDto>(list.Count, list);
        }

        public async Task<TaskDto> GetAsync(EntityDto input)
        {
            return ObjectMapper.Map<TaskDto>(await _taskDomainService.GetbyId(input.Id));
        }

        public async Task<List<TaskDto>> GetCurrentUserTasks()
        {
            return ObjectMapper.Map<List<TaskDto>>(await _taskDomainService.GetCurrentUserTasks());
        }

        public async Task<UpdateTaskDto> GetForEditAsync(EntityDto input)
        {
            return ObjectMapper.Map<UpdateTaskDto>(await _taskDomainService.GetbyId(input.Id));
        }

        public async Task<TaskDto> UpdateAsync(UpdateTaskDto input)
        {
            return ObjectMapper.Map<TaskDto>(await _taskDomainService.Update(ObjectMapper.Map<Task>(input)));

        }
    }
}

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
    public class TaskTypeAppService : TaskLogAppServiceBase, ITaskTypeAppService
    {
        private readonly ITaskTypeDomainService _taskTypeDomainService;

        public TaskTypeAppService(ITaskTypeDomainService taskTypeDomainService)
        {
            _taskTypeDomainService = taskTypeDomainService;
        }

        public async Task<TaskTypeDto> CreateAsync(CreateTaskTypeDto input)
        {
            return ObjectMapper.Map<TaskTypeDto>(await _taskTypeDomainService.Insert(ObjectMapper.Map<TaskType>(input)));
        }

        public async Task DeleteAsync(EntityDto input)
        {
            await _taskTypeDomainService.Delete(input.Id);
        }

        public PagedResultDto<TaskTypeDto> GetAll(PagedTaskTypeResultRequestDto input)
        {
            var taskTypes = _taskTypeDomainService.GetForGrid(input.Keyword);
            taskTypes = taskTypes.Skip(input.SkipCount).Take(input.MaxResultCount);

            var list = ObjectMapper.Map<List<TaskTypeDto>>(taskTypes.ToList());
            return new PagedResultDto<TaskTypeDto>(list.Count, list);
        }

        public async Task<TaskTypeDto> GetAsync(EntityDto input)
        {
            return ObjectMapper.Map<TaskTypeDto>(await _taskTypeDomainService.GetbyId(input.Id));
        }

        public async Task<UpdateTaskTypeDto> GetForEditAsync(EntityDto input)
        {
            return ObjectMapper.Map<UpdateTaskTypeDto>(await _taskTypeDomainService.GetbyId(input.Id));
        }

        public async Task<TaskTypeDto> UpdateAsync(UpdateTaskTypeDto input)
        {
            return ObjectMapper.Map<TaskTypeDto>(await _taskTypeDomainService.Update(ObjectMapper.Map<TaskType>(input)));
        }
    }
}

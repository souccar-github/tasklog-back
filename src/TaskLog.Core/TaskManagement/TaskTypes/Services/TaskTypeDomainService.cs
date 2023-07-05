using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.TaskTypes.Services
{
    public class TaskTypeDomainService : ITaskTypeDomainService
    {
        private readonly IRepository<TaskType> _taskTypeRepository;

        public TaskTypeDomainService(IRepository<TaskType> taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }

        public async Task Delete(int taskTypeId)
        {
            await _taskTypeRepository.DeleteAsync(taskTypeId);
        }

        public async Task<List<TaskType>> GetAll()
        {
            return await _taskTypeRepository.GetAllListAsync();
        }

        public async Task<TaskType> GetbyId(int id)
        {
            return await _taskTypeRepository.GetAsync(id);
        }

        public IQueryable<TaskType> GetForGrid(string keyword)
        {
            return _taskTypeRepository.GetAll().Where(x => x.Name.Contains(keyword));
        }

        public async Task<TaskType> Insert(TaskType taskType)
        {
            int newTaskTypeId = await _taskTypeRepository.InsertAndGetIdAsync(taskType);
            return await _taskTypeRepository.GetAsync(newTaskTypeId);
        }

        public async Task<TaskType> Update(TaskType taskType)
        {
            return await _taskTypeRepository.UpdateAsync(taskType);
        }
    }
}

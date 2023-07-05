using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Tasks.Services
{
    public class TaskDomainService : ITaskDomainService
    {
        private readonly IRepository<TaskLog.TaskManagement.Tasks.Task> _taskRepository;
        private readonly IAbpSession _abpSession;

        public TaskDomainService(IRepository<TaskLog.TaskManagement.Tasks.Task> taskRepository, IAbpSession abpSession)
        {
            _taskRepository = taskRepository;
            _abpSession = abpSession;
        }

        public async System.Threading.Tasks.Task Delete(int taskId)
        {
            await _taskRepository.DeleteAsync(taskId);
        }

        public async Task<List<Task>> GetAll()
        {
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).ToList();
        }

        public async Task<Task> GetbyId(int id)
        {
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Task>> GetCurrentUserTasks()
        {
            long userId = _abpSession.GetUserId();
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).Where(x => x.AssignedToId == userId).ToList();
        }

        public async Task<Task> Insert(Task task)
        {
            int newTaskId = await _taskRepository.InsertAndGetIdAsync(task);
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).FirstOrDefault(x => x.Id == newTaskId);
        }

        public async Task<Task> Update(Task task)
        {
            return await _taskRepository.UpdateAsync(task);
        }
    }
}

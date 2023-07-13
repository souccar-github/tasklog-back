using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace TaskLog.TaskManagement.Tasks.Services
{
    public interface ITaskDomainService : IDomainService
    {
        IQueryable<TaskLog.TaskManagement.Tasks.Task> GetForGrid(string keyword, int phaseId);
        System.Threading.Tasks.Task<List<TaskLog.TaskManagement.Tasks.Task>> GetAll();
        System.Threading.Tasks.Task<List<TaskLog.TaskManagement.Tasks.Task>> GetCurrentUserTasks();
        System.Threading.Tasks.Task<TaskLog.TaskManagement.Tasks.Task> GetbyId(int id);
        System.Threading.Tasks.Task<TaskLog.TaskManagement.Tasks.Task> Insert(TaskLog.TaskManagement.Tasks.Task task);
        System.Threading.Tasks.Task<TaskLog.TaskManagement.Tasks.Task> Update(TaskLog.TaskManagement.Tasks.Task task);
        System.Threading.Tasks.Task Delete(int taskId);
        System.Threading.Tasks.Task StartTask(int id);
        System.Threading.Tasks.Task CompleteTask(int id);
    }
}

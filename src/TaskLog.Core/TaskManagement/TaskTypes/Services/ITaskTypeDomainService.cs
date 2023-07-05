using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.TaskTypes.Services
{
    public interface ITaskTypeDomainService : IDomainService
    {
        IQueryable<TaskType> GetForGrid(string keyword);
        Task<List<TaskType>> GetAll();
        Task<TaskType> GetbyId(int id);
        Task<TaskType> Insert(TaskType taskType);
        Task<TaskType> Update(TaskType taskType);
        Task Delete(int taskTypeId);
    }
}

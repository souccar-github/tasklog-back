using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.TaskTypes.Services
{
    public interface ITaskTypeDomainService : IDomainService
    {
        Task<List<TaskType>> GetAll();
        Task<TaskType> GetbyId(int id);
        Task<TaskType> Insert(TaskType taskType);
        Task<TaskType> Update(TaskType taskType);
        Task Delete(int taskTypeId);
    }
}

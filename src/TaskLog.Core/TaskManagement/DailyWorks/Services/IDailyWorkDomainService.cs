using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.DailyWorks.Services
{
    public interface IDailyWorkDomainService : IDomainService
    {
        List<DailyWork> GetAll();
        Task<DailyWork> GetById(int id);
        Task<DailyWork> Insert(DailyWork dailyWork);
        Task<DailyWork> Update(DailyWork dailyWork);
        Task Delete(int dailyWorkId);
    }
}

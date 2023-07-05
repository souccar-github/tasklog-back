using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.DailyWorks.Services
{
    public interface IDailyWorkDomainService : IDomainService
    {
        IQueryable<DailyWork> GetForGrid(string keyword);
        List<DailyWork> GetAll();
        Task<DailyWork> GetById(int id);
        Task<DailyWork> Insert(DailyWork dailyWork);
        Task<DailyWork> Update(DailyWork dailyWork);
        Task Delete(int dailyWorkId);
    }
}

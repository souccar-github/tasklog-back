using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.DailyWorks.Services
{
    public class DailyWorkDomainService : IDailyWorkDomainService
    {
        private readonly IRepository<DailyWork> _dailyWorkRepository;

        public DailyWorkDomainService(IRepository<DailyWork> dailyWorkRepository)
        {
            _dailyWorkRepository = dailyWorkRepository;
        }

        public async Task Delete(int dailyWorkId)
        {
            await _dailyWorkRepository.DeleteAsync(dailyWorkId);
        }

        public List<DailyWork> GetAll()
        {
            return _dailyWorkRepository.GetAllIncluding(x => x.Project, x => x.Type).ToList();
        }

        public async Task<DailyWork> GetById(int id)
        {
            var dailyWork = await _dailyWorkRepository.GetAsync(id);
            if(dailyWork!=null)
            {
                await _dailyWorkRepository.EnsurePropertyLoadedAsync(dailyWork,x => x.Project);
                await _dailyWorkRepository.EnsurePropertyLoadedAsync(dailyWork,x => x.Type);
            }
            return dailyWork;
        }

        public IQueryable<DailyWork> GetForGrid(string keyword)
        {
            return _dailyWorkRepository.GetAllIncluding(x => x.Project,x => x.Type).Where(x => x.Project.Name.Contains(keyword));
        }

        public Task<DailyWork> Insert(DailyWork dailyWork)
        {
            throw new NotImplementedException();
        }

        public Task<DailyWork> Update(DailyWork dailyWork)
        {
            throw new NotImplementedException();
        }
    }
}

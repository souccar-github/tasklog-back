using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Phases.Services
{
    public class PhaseDomainService : IPhaseDomainService
    {
        private readonly IRepository<Phase> _phaseRepository;

        public PhaseDomainService(IRepository<Phase> phaseRepository)
        {
            _phaseRepository = phaseRepository;
        }

        public async Task CompletePhase(int phaseId)
        {
            var phase = await _phaseRepository.GetAsync(phaseId);
            if (phase == null)
            {
                await _phaseRepository.EnsurePropertyLoadedAsync(phase, x => x.Tasks);
            }
            var notCompletedTasks = phase.Tasks.Where(x => x.Status != Enums.TaskStatus.Completed).ToList();

            if (notCompletedTasks.Count > 0)
            {
                throw new UserFriendlyException(400, "Not all Tasks Completed");
            }
            else
            {
                phase.EndDate = DateTime.Now;
            }
        }

        public async Task Delete(int phaseId)
        {
            await _phaseRepository.DeleteAsync(phaseId);
        }

        public async Task<List<Phase>> GetAll()
        {
            return _phaseRepository.GetAllIncluding(x => x.Tasks, x => x.Project).ToList();
        }

        public async Task<Phase> GetById(int id)
        {
            var phase = await _phaseRepository.GetAsync(id);
            if(phase == null)
            {
                await _phaseRepository.EnsurePropertyLoadedAsync(phase, x => x.Project);
                await _phaseRepository.EnsurePropertyLoadedAsync(phase, x => x.Tasks);
            }
            return phase;
        }

        public IQueryable<Phase> GetForGrid(string keyword)
        {
            return _phaseRepository.GetAllIncluding(x => x.Project,x => x.Tasks).Where(x => x.Title.Contains(keyword));
        }

        public async Task<Phase> Insert(Phase phase)
        {
            phase.StartDate = DateTime.Now;
            int newPhaseId = await _phaseRepository.InsertAndGetIdAsync(phase);
            return _phaseRepository.GetAllIncluding(x => x.Tasks, x => x.Project).FirstOrDefault(x => x.Id == newPhaseId);
        }

        public async Task<Phase> Update(Phase phase)
        {
            return await _phaseRepository.UpdateAsync(phase);
        }
    }
}

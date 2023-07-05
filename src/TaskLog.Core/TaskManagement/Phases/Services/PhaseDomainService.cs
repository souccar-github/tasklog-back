using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Delete(int phaseId)
        {
            await _phaseRepository.DeleteAsync(phaseId);
        }

        public async Task<List<Phase>> GetAll()
        {
            return _phaseRepository.GetAllIncluding(x => x.Tasks, x => x.Project).ToList();
        }

        public async Task<Phase> GetbyId(int id)
        {
            return _phaseRepository.GetAllIncluding(x => x.Tasks, x => x.Project).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Phase> Insert(Phase phase)
        {
            int newPhaseId = await _phaseRepository.InsertAndGetIdAsync(phase);
            return _phaseRepository.GetAllIncluding(x => x.Tasks, x => x.Project).FirstOrDefault(x => x.Id == newPhaseId);
        }

        public async Task<Phase> Update(Phase phase)
        {
            return await _phaseRepository.UpdateAsync(phase);
        }
    }
}

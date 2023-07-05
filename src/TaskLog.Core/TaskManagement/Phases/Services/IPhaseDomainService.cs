using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Phases.Services
{
    public interface IPhaseDomainService : IDomainService
    {
        IQueryable<Phase> GetForGrid(string keyword);
        Task<List<Phase>> GetAll();
        Task<Phase> GetById(int id);
        Task<Phase> Insert(Phase phase);
        Task<Phase> Update(Phase phase);
        Task Delete(int phaseId);
        Task CompletePhase(int phaseId);
    }
}

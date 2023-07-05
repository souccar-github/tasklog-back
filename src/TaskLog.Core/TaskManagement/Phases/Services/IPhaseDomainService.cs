using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Phases.Services
{
    public interface IPhaseDomainService : IDomainService
    {
        Task<List<Phase>> GetAll();
        Task<Phase> GetbyId(int id);
        Task<Phase> Insert(Phase phase);
        Task<Phase> Update(Phase phase);
        Task Delete(int phaseId);
    }
}

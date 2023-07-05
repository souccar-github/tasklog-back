using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Projects.Services
{
    public interface IProjectDomainService : IDomainService
    {
        IQueryable<Project> GetForGrid(string keyword);
        List<Project> GetAll();
        Task<Project> GetByIdAsync(int id);
        Task<Project> InsertAsync(Project project);
        Task<Project> UpdateAsync(Project project);
        Task DeleteAsync(int projectId);
    }
}

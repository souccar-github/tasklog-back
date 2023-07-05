using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Projects.Services
{
    public class ProjectDomainService : IProjectDomainService
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectDomainService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<Project> GetAll()
        {
            return _projectRepository.GetAllIncluding(x => x.Phases).ToList();
        }

        public IQueryable<Project> GetForGrid(string keyword)
        {
            return _projectRepository.GetAllIncluding(x => x.Phases).Where(x=>x.Name.Contains(keyword));
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _projectRepository.GetAsync(id);
            await _projectRepository.EnsureCollectionLoadedAsync(project, x => x.Phases);
            return project;
        }

        public async Task<Project> InsertAsync(Project project)
        {
            int newProjectId = await _projectRepository.InsertAndGetIdAsync(project);
            return await _projectRepository.GetAsync(newProjectId);
        }

        public async Task<Project> UpdateAsync(Project project)
        {
            return await _projectRepository.UpdateAsync(project);
        }

        public async Task DeleteAsync(int projectId)
        {
            await _projectRepository.DeleteAsync(projectId);
        }

    }
}

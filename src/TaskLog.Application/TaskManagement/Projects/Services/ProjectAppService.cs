using Abp.Application.Services.Dto;
using Abp.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Projects;
using TaskLog.TaskManagement.Projects.Dto;
using TaskLog.TaskManagement.Projects.Services;
using TaskLog.TaskManagement.TaskLogs.Dto;

namespace TaskLog.TaskManagement.TaskLogs.Services
{
    public class ProjectAppService : TaskLogAppServiceBase, IProjectAppService
    {
        private readonly IProjectDomainService _projectDomainService;

        public ProjectAppService(IProjectDomainService projectDomainService)
        {
            _projectDomainService = projectDomainService;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
            var project = ObjectMapper.Map<Project>(input);
            var createdProject = await _projectDomainService.InsertAsync(project);
            return ObjectMapper.Map<ProjectDto>(createdProject);
        }

        public async Task DeleteAsync(EntityDto input)
        {
            await _projectDomainService.DeleteAsync(input.Id);
        }

        public PagedResultDto<ProjectDto> GetAll(PagedProjectResultRequestDto input)
        {
            var projects = _projectDomainService.GetForGrid(input.Keyword);
            int total = projects.Count();
            projects = projects.Skip(input.SkipCount).Take(input.MaxResultCount);

            var list = ObjectMapper.Map<List<ProjectDto>>(projects.ToList());
            return new PagedResultDto<ProjectDto>(total, list);
        }

        public async Task<ProjectDto> GetAsync(EntityDto input)
        {
            var project = await _projectDomainService.GetByIdAsync(input.Id);
            if(project == null)
            {
                throw new UserFriendlyException("");
            }

            return ObjectMapper.Map<ProjectDto>(project);
        }

        public async Task<UpdateProjectDto> GetForEditAsync(EntityDto input)
        {
            var project = await _projectDomainService.GetByIdAsync(input.Id);
            if (project == null)
            {
                throw new UserFriendlyException("");
            }

            return ObjectMapper.Map<UpdateProjectDto>(project);
        }

        public async Task<ProjectDto> UpdateAsync(UpdateProjectDto input)
        {
            var project = await _projectDomainService.GetByIdAsync(input.Id);
            if (project == null)
            {
                throw new UserFriendlyException("");
            }
            ObjectMapper.Map<UpdateProjectDto, Project>(input, project);
            var updatedProject = await _projectDomainService.UpdateAsync(project);
            return ObjectMapper.Map<ProjectDto>(updatedProject);
        }
    }
}

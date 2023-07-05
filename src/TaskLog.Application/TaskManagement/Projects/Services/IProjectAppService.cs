using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Projects.Dto;
using TaskLog.TaskManagement.TaskLogs.Dto;

namespace TaskLog.TaskManagement.TaskLogs.Services
{
    public interface IProjectAppService : IApplicationService
    {
        PagedResultDto<ProjectDto> GetAll(PagedProjectResultRequestDto input);
        Task<UpdateProjectDto> GetForEditAsync(EntityDto input);
        Task<ProjectDto> GetAsync(EntityDto input);
        Task<ProjectDto> CreateAsync(CreateProjectDto input);
        Task<ProjectDto> UpdateAsync(UpdateProjectDto input);
        Task DeleteAsync(EntityDto input);
    }
}

using AutoMapper;
using TaskLog.TaskManagement.Projects.Dto;
using TaskLog.TaskManagement.TaskLogs.Dto;

namespace TaskLog.TaskManagement.Projects.Map
{
    public class ProjectMapProfile: Profile
    {
        public ProjectMapProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<Project, CreateProjectDto>();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<Project, UpdateProjectDto>();
            CreateMap<UpdateProjectDto, Project>();
        }
    }
}

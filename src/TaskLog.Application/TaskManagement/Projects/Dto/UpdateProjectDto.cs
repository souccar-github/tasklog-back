using Abp.Application.Services.Dto;

namespace TaskLog.TaskManagement.Projects.Dto
{
    public class UpdateProjectDto: EntityDto
    {
        public string Name { get; set; }
    }
}

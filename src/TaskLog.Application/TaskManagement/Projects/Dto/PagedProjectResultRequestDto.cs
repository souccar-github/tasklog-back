using Abp.Application.Services.Dto;

namespace TaskLog.TaskManagement.TaskLogs.Dto
{
    public class PagedProjectResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


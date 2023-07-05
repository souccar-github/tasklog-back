using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.TaskLogs.Dto;

namespace TaskLog.TaskManagement.Phases.Dto
{
    public class PhaseDto : EntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectDto Project { get; set; }
    }
}

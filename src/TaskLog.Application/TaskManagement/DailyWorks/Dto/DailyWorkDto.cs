using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.TaskLogs.Dto;
using TaskLog.TaskManagement.TaskTypes.Dto;

namespace TaskLog.TaskManagement.DailyWorks.Dto
{
    public class DailyWorkDto : EntityDto
    {
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public ProjectDto Project { get; set; }
        public TaskTypeDto Type { get; set; }
    }
}

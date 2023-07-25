using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Phases.Dto;
using TaskLog.TaskManagement.TaskTypes.Dto;
using TaskLog.Users.Dto;

namespace TaskLog.TaskManagement.Tasks.Dto
{
    public class TaskDto : EntityDto
    {
        public bool isBug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PhaseDto Phase { get; set; }
        public int Status { get; set; }
        public UserDto AssignedTo { get; set; }
        public TaskTypeDto Type { get; set; }
        public int Priority { get; set; }
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.TaskTypes.Dto
{
    public class TaskTypeDto : EntityDto
    {
        public string Name { get; set; }
    }
}

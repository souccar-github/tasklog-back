using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.DailyWorks.Dto
{
    public class UpdateDailyWorkDto : EntityDto
    {
        public string Date { get; set; }
        public double Duration { get; set; }
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
    }
}

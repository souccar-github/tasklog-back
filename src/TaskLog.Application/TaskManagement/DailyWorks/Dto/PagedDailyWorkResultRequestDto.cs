using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.DailyWorks.Dto
{
    public class PagedDailyWorkResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

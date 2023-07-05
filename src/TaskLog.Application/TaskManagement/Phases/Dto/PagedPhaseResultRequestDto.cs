using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Phases.Dto
{
    public class PagedPhaseResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

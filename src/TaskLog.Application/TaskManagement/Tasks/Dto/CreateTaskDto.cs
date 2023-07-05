using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.Tasks.Dto
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PhaseId { get; set; }
        public int Status { get; set; }
        public long AssignedToId { get; set; }
        public int TypeId { get; set; }
        public int Priority { get; set; }
    }
}

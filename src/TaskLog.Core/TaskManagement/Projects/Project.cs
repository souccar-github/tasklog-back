using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using TaskLog.TaskManagement.Phases;

namespace TaskLog.TaskManagement.Projects
{
    public class Project : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
        public List<Phase> Phases { get; set; }
    }
}

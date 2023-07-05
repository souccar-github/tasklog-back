using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Projects;
using TaskLog.TaskManagement.TaskTypes;

namespace TaskLog.TaskManagement.DailyWorks
{
    public class DailyWork : FullAuditedAggregateRoot
    {
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        #region Project
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
        #region TaskType
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public TaskType Type { get; set; }
        #endregion

    }
}

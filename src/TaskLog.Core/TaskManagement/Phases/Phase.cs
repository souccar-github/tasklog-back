using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TaskLog.TaskManagement.Projects;
using TaskLog.TaskManagement.Tasks;

namespace TaskLog.TaskManagement.Phases
{
    public class Phase : FullAuditedAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #region Project
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
        public List<Task> Tasks { get; set; }
    }
}

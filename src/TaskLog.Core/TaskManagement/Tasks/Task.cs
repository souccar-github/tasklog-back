using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TaskLog.Authorization.Users;
using TaskLog.TaskManagement.Enums;
using TaskLog.TaskManagement.Phases;
using TaskLog.TaskManagement.TaskTypes;

namespace TaskLog.TaskManagement.Tasks
{
    public class Task : FullAuditedAggregateRoot
    {
        public DateTime? CreationDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public bool isBug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        #region Phase
        [ForeignKey("Phase")]
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
        #endregion
        public TaskStatus Status { get; set; }
        #region User
        [ForeignKey("AssignedTo")]
        public long AssignedToId { get; set; }
        public User AssignedTo { get; set; }
        #endregion
        #region TaskType
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public TaskType Type { get; set; }
        #endregion
        public TaskPriority Priority { get; set; }
    }
}

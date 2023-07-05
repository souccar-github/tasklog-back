﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.TaskTypes
{
    public class TaskType : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLog.TaskManagement.DailyWorks.Dto
{
    public class CreateDailyWorkDto
    {
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
    }
}

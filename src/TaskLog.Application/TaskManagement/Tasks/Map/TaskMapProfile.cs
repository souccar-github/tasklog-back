using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Tasks.Dto;
using TaskLog.TaskManagement.TaskTypes;

namespace TaskLog.TaskManagement.Tasks.Map
{
    public class TaskMapProfile : Profile
    {
        public TaskMapProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();
            CreateMap<Task, CreateTaskDto>();
            CreateMap<CreateTaskDto, Task>();
            CreateMap<Task, UpdateTaskDto>();
            CreateMap<UpdateTaskDto, Task>();
        }
    }
}

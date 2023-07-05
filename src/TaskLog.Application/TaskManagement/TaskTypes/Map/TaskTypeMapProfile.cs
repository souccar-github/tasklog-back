using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.TaskTypes.Dto;

namespace TaskLog.TaskManagement.TaskTypes.Map
{
    public class TaskTypeMapProfile : Profile
    {
        public TaskTypeMapProfile()
        {
            CreateMap<TaskType, TaskTypeDto>();
            CreateMap<TaskTypeDto, TaskType>();
            CreateMap<TaskType, CreateTaskTypeDto>();
            CreateMap<CreateTaskTypeDto, TaskType>();
            CreateMap<TaskType, UpdateTaskTypeDto>();
            CreateMap<UpdateTaskTypeDto, TaskType>();
        }
    }
}

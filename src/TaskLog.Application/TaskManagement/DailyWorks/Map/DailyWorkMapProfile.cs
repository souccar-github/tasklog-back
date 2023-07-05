using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.DailyWorks.Dto;

namespace TaskLog.TaskManagement.DailyWorks.Map
{
    public class DailyWorkMapProfile : Profile
    {
        public DailyWorkMapProfile()
        {
            CreateMap<DailyWork, DailyWorkDto>();
            CreateMap<DailyWorkDto, DailyWork>();
            CreateMap<DailyWork, CreateDailyWorkDto>();
            CreateMap<CreateDailyWorkDto, DailyWork>();
            CreateMap<DailyWork, UpdateDailyWorkDto>();
            CreateMap<UpdateDailyWorkDto, DailyWork>();
        }
    }
}

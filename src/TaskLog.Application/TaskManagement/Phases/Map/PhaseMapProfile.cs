using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Phases.Dto;

namespace TaskLog.TaskManagement.Phases.Map
{
    public class PhaseMapProfile : Profile
    {
        public PhaseMapProfile()
        {
            CreateMap<Phase, PhaseDto>();
            CreateMap<PhaseDto, Phase>();
            CreateMap<Phase, CreatePhaseDto>();
            CreateMap<CreatePhaseDto, Phase>();
            CreateMap<Phase, UpdatePhaseDto>();
            CreateMap<UpdatePhaseDto, Phase>();
        }
    }
}

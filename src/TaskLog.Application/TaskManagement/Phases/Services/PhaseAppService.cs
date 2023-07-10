using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.Phases.Dto;
using TaskLog.TaskManagement.TaskLogs.Dto;

namespace TaskLog.TaskManagement.Phases.Services
{
    public class PhaseAppService : TaskLogAppServiceBase, IPhaseAppService
    {
        private readonly IPhaseDomainService _phaseDomainService;

        public PhaseAppService(IPhaseDomainService phaseDomainService)
        {
            _phaseDomainService = phaseDomainService;
        }

        public async Task CompletePhase(EntityDto input)
        {
            await _phaseDomainService.CompletePhase(input.Id);
        }

        public async Task<PhaseDto> CreateAsync(CreatePhaseDto input)
        {
            return ObjectMapper.Map<PhaseDto>(await _phaseDomainService.Insert(ObjectMapper.Map<Phase>(input)));
        }

        public async Task DeleteAsync(EntityDto input)
        {
            await _phaseDomainService.Delete(input.Id);
        }

        public PagedResultDto<PhaseDto> GetAll(PagedPhaseResultRequestDto input)
        {
            var phases = _phaseDomainService.GetForGrid(input.Keyword,input.ProjectId);
            phases = phases.Skip(input.SkipCount).Take(input.MaxResultCount);

            var list = ObjectMapper.Map<List<PhaseDto>>(phases.ToList());
            return new PagedResultDto<PhaseDto>(list.Count, list);
        }

        public async Task<PhaseDto> GetAsync(EntityDto input)
        {
            return ObjectMapper.Map<PhaseDto>(await _phaseDomainService.GetById(input.Id));
        }

        public async Task<UpdatePhaseDto> GetForEditAsync(EntityDto input)
        {
            return ObjectMapper.Map<UpdatePhaseDto>(await _phaseDomainService.GetById(input.Id));
        }

        public async Task<PhaseDto> UpdateAsync(UpdatePhaseDto input)
        {
            return ObjectMapper.Map<PhaseDto>(await _phaseDomainService.Update(ObjectMapper.Map<Phase>(input)));
        }
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLog.TaskManagement.DailyWorks.Dto;
using TaskLog.TaskManagement.Phases.Dto;

namespace TaskLog.TaskManagement.DailyWorks.Services
{
    public class DailyWorkAppService : TaskLogAppServiceBase, IDailyWorkAppService
    {
        private readonly IDailyWorkDomainService _dailyWorkDomainService;

        public DailyWorkAppService(IDailyWorkDomainService dailyWorkDomainService)
        {
            _dailyWorkDomainService = dailyWorkDomainService;
        }

        public async Task<DailyWorkDto> CreateAsync(CreateDailyWorkDto input)
        {
            return ObjectMapper.Map<DailyWorkDto>(await _dailyWorkDomainService.Insert(ObjectMapper.Map<DailyWork>(input)));
        }

        public async Task DeleteAsync(EntityDto input)
        {
            await _dailyWorkDomainService.Delete(input.Id);
        }

        public PagedResultDto<DailyWorkDto> GetAll(PagedPhaseResultRequestDto input)
        {
            var dailyWorks = _dailyWorkDomainService.GetForGrid(input.Keyword);
            dailyWorks = dailyWorks.Skip(input.SkipCount).Take(input.MaxResultCount);

            var list = ObjectMapper.Map<List<DailyWorkDto>>(dailyWorks.ToList());
            return new PagedResultDto<DailyWorkDto>(list.Count, list);
        }

        public async Task<DailyWorkDto> GetAsync(EntityDto input)
        {
            return ObjectMapper.Map<DailyWorkDto>(await _dailyWorkDomainService.GetById(input.Id));
        }

        public async Task<UpdateDailyWorkDto> GetForEditAsync(EntityDto input)
        {
            return ObjectMapper.Map<UpdateDailyWorkDto>(await _dailyWorkDomainService.GetById(input.Id));
        }

        public async Task<DailyWorkDto> UpdateAsync(UpdateDailyWorkDto input)
        {
            return ObjectMapper.Map<DailyWorkDto>(await _dailyWorkDomainService.Update(ObjectMapper.Map<DailyWork>(input)));
        }
    }
}

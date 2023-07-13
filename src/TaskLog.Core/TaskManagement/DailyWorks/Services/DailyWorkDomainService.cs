using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskLog.Authorization.Roles;
using TaskLog.Authorization.Users;

namespace TaskLog.TaskManagement.DailyWorks.Services
{
    public class DailyWorkDomainService : IDailyWorkDomainService
    {
        private readonly IRepository<DailyWork> _dailyWorkRepository;
        private readonly IAbpSession _abpSession;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<User, long> _userRepository;

        public DailyWorkDomainService(IRepository<DailyWork> dailyWorkRepository, IAbpSession abpSession, UserManager userManager, RoleManager roleManager, IRepository<User, long> userRepository)
        {
            _dailyWorkRepository = dailyWorkRepository;
            _abpSession = abpSession;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        public async Task Delete(int dailyWorkId)
        {
            await _dailyWorkRepository.DeleteAsync(dailyWorkId);
        }

        public List<DailyWork> GetAll()
        {
            return _dailyWorkRepository.GetAllIncluding(x => x.Project, x => x.Type).ToList();
        }

        public async Task<DailyWork> GetById(int id)
        {
            var dailyWork = await _dailyWorkRepository.GetAsync(id);
            if(dailyWork!=null)
            {
                await _dailyWorkRepository.EnsurePropertyLoadedAsync(dailyWork,x => x.Project);
                await _dailyWorkRepository.EnsurePropertyLoadedAsync(dailyWork,x => x.Type);
            }
            return dailyWork;
        }

        public IQueryable<DailyWork> GetForGrid(string keyword)
        {

            User user = _userManager.GetUserById((long)_abpSession.GetUserId());
            var currentUser = _userRepository.FirstOrDefault(x => x.Id == user.Id);
            if(currentUser != null)
            {
                _userRepository.EnsureCollectionLoaded(currentUser, x => x.Roles);
            }
            //Role role = _roleManager.GetRoleByName("admin");
            //if (user.Roles.FirstOrDefault(x => x.RoleId == role.Id) != null)
            if(currentUser.Roles.FirstOrDefault(x => x.RoleId == 1) != null)
            {
                if (keyword != null)
                    return _dailyWorkRepository.GetAllIncluding(x => x.Project, x => x.Type,x => x.User).Where(x => x.Project.Name.Contains(keyword)).OrderByDescending(x => x.Id);
                    return _dailyWorkRepository.GetAllIncluding(x => x.Project, x => x.Type, x => x.User).OrderByDescending(x => x.Id);
            }
            else
            {
                if (keyword != null)
                    return _dailyWorkRepository.GetAllIncluding(x => x.Project, x => x.Type, x => x.User).Where(x => x.Project.Name.Contains(keyword) && x.UserId == user.Id).OrderByDescending(x => x.Id);
                    return _dailyWorkRepository.GetAllIncluding(x => x.Project, x => x.Type, x => x.User).Where(x => x.UserId == user.Id).OrderByDescending(x => x.Id);
            }
           
        }

        public async Task<DailyWork> Insert(DailyWork dailyWork)
        {
            dailyWork.UserId = (long)_abpSession.UserId;
            return await _dailyWorkRepository.InsertAsync(dailyWork);
        }

        public async Task<DailyWork> Update(DailyWork dailyWork)
        {
            dailyWork.UserId = (long)_abpSession.UserId;
            return await _dailyWorkRepository.UpdateAsync(dailyWork);
        }
    }
}

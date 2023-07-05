using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLog.Authorization.Roles;
using TaskLog.Authorization.Users;

namespace TaskLog.TaskManagement.Tasks.Services
{
    public class TaskDomainService : ITaskDomainService
    {
        private readonly IRepository<TaskLog.TaskManagement.Tasks.Task> _taskRepository;
        private readonly IAbpSession _abpSession;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public TaskDomainService(IRepository<TaskLog.TaskManagement.Tasks.Task> taskRepository, IAbpSession abpSession, UserManager userManager, RoleManager roleManager)
        {
            _taskRepository = taskRepository;
            _abpSession = abpSession;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async System.Threading.Tasks.Task Delete(int taskId)
        {
            await _taskRepository.DeleteAsync(taskId);
        }

        public async Task<List<Task>> GetAll()
        {
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).ToList();
        }

        public async Task<Task> GetbyId(int id)
        {
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Task>> GetCurrentUserTasks()
        {
            long userId = _abpSession.GetUserId();
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).Where(x => x.AssignedToId == userId).ToList();
        }

        public IQueryable<Task> GetForGrid(string keyword)
        {
            User user = _userManager.GetUserById((long)_abpSession.GetUserId());
            Role role = _roleManager.GetRoleByName("admin");
            if(user.Roles.FirstOrDefault(x => x.RoleId == role.Id) != null)
            {
                return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.Title.Contains(keyword));
            }
            else
            {
                return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.Title.Contains(keyword) && x.AssignedToId == user.Id);
            }
        }

        public async Task<Task> Insert(Task task)
        {
            int newTaskId = await _taskRepository.InsertAndGetIdAsync(task);
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).FirstOrDefault(x => x.Id == newTaskId);
        }

        public async Task<Task> Update(Task task)
        {
            return await _taskRepository.UpdateAsync(task);
        }
    }
}

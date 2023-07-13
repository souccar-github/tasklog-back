using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLog.Authorization.Roles;
using TaskLog.Authorization.Users;
using TaskLog.TaskManagement.Projects;

namespace TaskLog.TaskManagement.Tasks.Services
{
    public class TaskDomainService : ITaskDomainService
    {
        private readonly IRepository<TaskLog.TaskManagement.Tasks.Task> _taskRepository;
        private readonly IRepository<User,long> _userRepository;
        private readonly IAbpSession _abpSession;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public TaskDomainService(IRepository<TaskLog.TaskManagement.Tasks.Task> taskRepository, IAbpSession abpSession, UserManager userManager, RoleManager roleManager, IRepository<User,long> userRepository)
        {
            _taskRepository = taskRepository;
            _abpSession = abpSession;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
        }

        public async System.Threading.Tasks.Task CompleteTask(int id)
        {
            var task = await _taskRepository.GetAsync(id);
            task.Status = Enums.TaskStatus.Completed;
            await _taskRepository.UpdateAsync(task);
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

        public IQueryable<Task> GetForGrid(string keyword, int phaseId)
        {
            User user = _userManager.GetUserById((long)_abpSession.GetUserId());
            if(user != null)
            {
                 _userRepository.EnsureCollectionLoaded(user,x => x.Roles);
            }
            Role role = _roleManager.GetRoleByName("admin");
            if(user.Roles.FirstOrDefault(x => x.RoleId == role.Id) != null)
            {
                if (keyword != null)
                {
                    if (phaseId != 0)
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.Title.Contains(keyword) && x.PhaseId == phaseId).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                    else
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.Title.Contains(keyword)).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                }
                else
                {
                    if (phaseId != 0)
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.PhaseId == phaseId).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                    else
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                }
            }
            else
            {
                if (keyword != null)
                {
                    if (phaseId != 0)
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.Title.Contains(keyword) && x.PhaseId == phaseId && x.AssignedToId == user.Id).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                    else
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.Title.Contains(keyword) && x.AssignedToId == user.Id).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                }
                else
                {
                    if (phaseId != 0)
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.PhaseId == phaseId && x.AssignedToId == user.Id).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                    else
                    {
                        return _taskRepository.GetAllIncluding(x => x.Type, x => x.AssignedTo, x => x.Phase).Where(x => x.AssignedToId == user.Id).OrderByDescending(x => x.Priority).ThenByDescending(x => x.Id);
                    }
                }
            }
            

        }

        public async Task<Task> Insert(Task task)
        {
            int newTaskId = await _taskRepository.InsertAndGetIdAsync(task);
            return _taskRepository.GetAllIncluding(x => x.AssignedTo, x => x.Phase, x => x.Type).FirstOrDefault(x => x.Id == newTaskId);
        }

        public async System.Threading.Tasks.Task StartTask(int id)
        {
            var task = await _taskRepository.GetAsync(id);
            task.Status = Enums.TaskStatus.Started;
            await _taskRepository.UpdateAsync(task);
        }

        public async Task<Task> Update(Task task)
        {
            return await _taskRepository.UpdateAsync(task);
        }
    }
}

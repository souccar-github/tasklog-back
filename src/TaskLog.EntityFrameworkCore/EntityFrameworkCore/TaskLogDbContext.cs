using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TaskLog.Authorization.Roles;
using TaskLog.Authorization.Users;
using TaskLog.MultiTenancy;
using TaskLog.TaskManagement.Projects;
using TaskLog.TaskManagement.Phases;
using TaskLog.TaskManagement.Tasks;
using TaskLog.TaskManagement.TaskTypes;
using TaskLog.TaskManagement.DailyWorks;

namespace TaskLog.EntityFrameworkCore
{
    public class TaskLogDbContext : AbpZeroDbContext<Tenant, Role, User, TaskLogDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TaskLogDbContext(DbContextOptions<TaskLogDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<DailyWork> DailyWorks { get; set; }
    }
}

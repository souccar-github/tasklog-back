using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TaskLog.EntityFrameworkCore
{
    public static class TaskLogDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TaskLogDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TaskLogDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

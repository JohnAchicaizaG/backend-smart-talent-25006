using Microsoft.EntityFrameworkCore;
using TaskManagerBackendSmartTalent.src.Entities;

namespace TaskManagerBackendSmartTalent.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
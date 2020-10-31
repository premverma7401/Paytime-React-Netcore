using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paytime.Domain;

namespace Paytime.Persistence
{
    public class DataContext : IdentityDbContext<UserModel>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<WeeklyDataModel> Timesheets { get; set; }
        public DbSet<DailyDataModel> DailyData { get; set; }
        public DbSet<ShiftDataModel> ShiftData { get; set; }

    }
}
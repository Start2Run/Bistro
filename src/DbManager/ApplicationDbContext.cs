using Microsoft.EntityFrameworkCore;
namespace DbManager
{
    public class ApplicationDbContext:DbContext
    {
        private static bool _created = false;

        public DbSet<Models.FoodProduct> FoodProducts { get; set; }
        public DbSet<Models.DailyMenu> DailyMenus { get; set; }
        public DbSet<Models.Log> Logs { get; set; }

        public ApplicationDbContext()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureCreated();
                //Database.EnsureDeleted();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=SystemePAC.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

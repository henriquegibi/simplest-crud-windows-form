using System.Data.Entity;

namespace simplest_crud_windows_form.Models
{
    class MyBDContext : DbContext
    {
        public MyBDContext() : base("MyDBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyBDContext, Migrations.Configuration>("MyDBConnectionString"));
        }

        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
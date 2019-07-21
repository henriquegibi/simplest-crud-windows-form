namespace simplest_crud_windows_form.Entities
{
    using System.Data.Entity;

    public partial class MyModel : DbContext
    {
        public MyModel() : base("MyDBConnectionStringl") { }

        public virtual DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}
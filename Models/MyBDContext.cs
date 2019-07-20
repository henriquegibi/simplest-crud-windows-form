using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simplest_crud_windows_form.Models
{
    class MyBDContext : DbContext
    {
        public MyBDContext() : base("MyDBConnectionString")
        {

        }

        public DbSet<Details> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

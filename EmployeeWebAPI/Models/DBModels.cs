using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EmployeeWebAPI.Models
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }

        public virtual DbSet<Employee2> Employee2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee2>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee2>()
                .Property(e => e.Position)
                .IsUnicode(false);
        }
    }
}

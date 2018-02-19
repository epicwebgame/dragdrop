using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ModelInClassLibrary
{
    public class ExperimentalDbContext : DbContext
    {
        public ExperimentalDbContext() : base("ExperimentalDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Foo> Foos { get; set; }
    }
}

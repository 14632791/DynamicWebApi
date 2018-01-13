using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Test.Models.Mapping;

namespace Metro.DynamicModeules.Test.Models
{
    public partial class CSFramework3SystemContext : DbContext
    {
        static CSFramework3SystemContext()
        {
            Database.SetInitializer<CSFramework3SystemContext>(null);
        }

        public CSFramework3SystemContext()
            : base("Name=CSFramework3SystemContext")
        {
        }

        public DbSet<tb_DataSet> tb_DataSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new tb_DataSetMap());
        }
    }
}

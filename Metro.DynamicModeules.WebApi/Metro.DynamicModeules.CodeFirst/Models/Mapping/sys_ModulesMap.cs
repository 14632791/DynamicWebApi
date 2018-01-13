using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class sys_ModulesMap : EntityTypeConfiguration<sys_Modules>
    {
        public sys_ModulesMap()
        {
            // Primary Key
            this.HasKey(t => t.ModuleID);

            // Properties
            this.Property(t => t.isid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ModuleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ModuleName)
                .HasMaxLength(50);

        }
    }
}

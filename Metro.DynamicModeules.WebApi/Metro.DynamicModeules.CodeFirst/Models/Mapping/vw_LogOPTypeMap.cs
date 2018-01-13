using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class vw_LogOPTypeMap : EntityTypeConfiguration<vw_LogOPType>
    {
        public vw_LogOPTypeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TypeID, t.TypeName });

            // Properties
            this.Property(t => t.TypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TypeName)
                .IsRequired()
                .HasMaxLength(4);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_PersonMap : EntityTypeConfiguration<tb_Person>
    {
        public tb_PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.SalesCode);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.SalesCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SalesName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Department)
                .HasMaxLength(20);

            this.Property(t => t.InUse)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}

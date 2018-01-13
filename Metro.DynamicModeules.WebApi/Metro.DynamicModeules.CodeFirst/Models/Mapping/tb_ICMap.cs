using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_ICMap : EntityTypeConfiguration<tb_IC>
    {
        public tb_ICMap()
        {
            // Primary Key
            this.HasKey(t => t.ICNO);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ICNO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DocUser)
                .HasMaxLength(20);

            this.Property(t => t.FlagApp)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.Remark)
                .HasMaxLength(250);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.AppUser)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}

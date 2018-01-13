using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_IAMap : EntityTypeConfiguration<tb_IA>
    {
        public tb_IAMap()
        {
            // Primary Key
            this.HasKey(t => t.IANO);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.IANO)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DocUser)
                .HasMaxLength(20);

            this.Property(t => t.Reason)
                .HasMaxLength(200);

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

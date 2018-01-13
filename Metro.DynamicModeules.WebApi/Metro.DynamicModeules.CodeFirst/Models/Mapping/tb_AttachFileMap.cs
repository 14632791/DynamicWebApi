using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_AttachFileMap : EntityTypeConfiguration<tb_AttachFile>
    {
        public tb_AttachFileMap()
        {
            // Primary Key
            this.HasKey(t => t.FileID);

            // Properties
            this.Property(t => t.DocID)
                .HasMaxLength(20);

            this.Property(t => t.FileTitle)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FileType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.IsDroped)
                .HasMaxLength(1);

        }
    }
}

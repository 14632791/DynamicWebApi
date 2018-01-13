using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyFormTagNameMap : EntityTypeConfiguration<tb_MyFormTagName>
    {
        public tb_MyFormTagNameMap()
        {
            // Primary Key
            this.HasKey(t => new { t.MenuName, t.TagValue });

            // Properties
            this.Property(t => t.AUID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.MenuName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.TagValue)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TagName)
                .HasMaxLength(20);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_CustomerAttributeMap : EntityTypeConfiguration<tb_CustomerAttribute>
    {
        public tb_CustomerAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.AttributeCode);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.AttributeCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.NativeName)
                .HasMaxLength(40);

            this.Property(t => t.EnglishName)
                .HasMaxLength(50);

            this.Property(t => t.IsSelected)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}

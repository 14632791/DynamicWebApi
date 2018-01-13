using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_PayTypeMap : EntityTypeConfiguration<tb_PayType>
    {
        public tb_PayTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.PayType);

            // Properties
            this.Property(t => t.isid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.PayType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.TypeName)
                .HasMaxLength(20);

        }
    }
}

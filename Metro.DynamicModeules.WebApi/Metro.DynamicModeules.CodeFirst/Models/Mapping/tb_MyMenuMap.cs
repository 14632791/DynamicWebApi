using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyMenuMap : EntityTypeConfiguration<tb_MyMenu>
    {
        public tb_MyMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.MenuName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MenuCaption)
                .HasMaxLength(50);

            this.Property(t => t.MenuType)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}

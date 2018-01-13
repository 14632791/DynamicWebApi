using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyUserGroupReMap : EntityTypeConfiguration<tb_MyUserGroupRe>
    {
        public tb_MyUserGroupReMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.GroupCode)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Account)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}

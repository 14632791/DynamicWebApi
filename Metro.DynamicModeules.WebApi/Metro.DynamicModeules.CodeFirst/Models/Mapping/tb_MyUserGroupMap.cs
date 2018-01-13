using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyUserGroupMap : EntityTypeConfiguration<tb_MyUserGroup>
    {
        public tb_MyUserGroupMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.GroupCode)
                .HasMaxLength(30);

            this.Property(t => t.GroupName)
                .HasMaxLength(100);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyUserRoleMap : EntityTypeConfiguration<tb_MyUserRole>
    {
        public tb_MyUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.GroupCode)
                .HasMaxLength(30);

            this.Property(t => t.AuthorityID)
                .HasMaxLength(50);

        }
    }
}

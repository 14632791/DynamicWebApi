using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_MyAuthorityItemMap : EntityTypeConfiguration<tb_MyAuthorityItem>
    {
        public tb_MyAuthorityItemMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.AuthorityName)
                .HasMaxLength(20);

        }
    }
}

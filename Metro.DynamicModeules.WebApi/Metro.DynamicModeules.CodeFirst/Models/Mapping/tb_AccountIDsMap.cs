using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_AccountIDsMap : EntityTypeConfiguration<tb_AccountIDs>
    {
        public tb_AccountIDsMap()
        {
            // Primary Key
            this.HasKey(t => t.AccID);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.AccID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.AccName)
                .HasMaxLength(50);

        }
    }
}

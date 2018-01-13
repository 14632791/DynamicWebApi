using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_LocationMap : EntityTypeConfiguration<tb_Location>
    {
        public tb_LocationMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationID);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.LocationID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.LocationName)
                .HasMaxLength(50);

        }
    }
}

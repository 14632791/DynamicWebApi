using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class sys_DataSNMap : EntityTypeConfiguration<sys_DataSN>
    {
        public sys_DataSNMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.DataCode)
                .HasMaxLength(10);

            this.Property(t => t.Header)
                .HasMaxLength(10);

        }
    }
}

using Metro.DynamicModeules.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_DataSetMap : EntityTypeConfiguration<tb_DataSet>
    {
        public tb_DataSetMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.DataSetID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.DataSetName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ServerIP)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DBName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.DBUserName)
                .HasMaxLength(50);

            this.Property(t => t.DBUserPassword)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(250);

        }
    }
}

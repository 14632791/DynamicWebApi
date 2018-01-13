using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.Test.Models.Mapping
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

            // Table & Column Mappings
            this.ToTable("tb_DataSet");
            this.Property(t => t.isid).HasColumnName("isid");
            this.Property(t => t.DataSetID).HasColumnName("DataSetID");
            this.Property(t => t.DataSetName).HasColumnName("DataSetName");
            this.Property(t => t.ServerIP).HasColumnName("ServerIP");
            this.Property(t => t.DBName).HasColumnName("DBName");
            this.Property(t => t.DBUserName).HasColumnName("DBUserName");
            this.Property(t => t.DBUserPassword).HasColumnName("DBUserPassword");
            this.Property(t => t.Remark).HasColumnName("Remark");
        }
    }
}

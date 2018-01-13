using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_LogMap : EntityTypeConfiguration<tb_Log>
    {
        public tb_LogMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.GUID32)
                .HasMaxLength(32);

            this.Property(t => t.LogUser)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.TableName)
                .HasMaxLength(30);

            this.Property(t => t.KeyFieldName)
                .HasMaxLength(20);

            this.Property(t => t.DocNo)
                .HasMaxLength(20);

            this.Property(t => t.IsMaster)
                .IsFixedLength()
                .HasMaxLength(1);

        }
    }
}

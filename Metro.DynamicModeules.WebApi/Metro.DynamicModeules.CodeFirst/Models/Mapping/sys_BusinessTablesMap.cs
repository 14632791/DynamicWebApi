using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class sys_BusinessTablesMap : EntityTypeConfiguration<sys_BusinessTables>
    {
        public sys_BusinessTablesMap()
        {
            // Primary Key
            this.HasKey(t => t.isid);

            // Properties
            this.Property(t => t.FormName)
                .HasMaxLength(50);

            this.Property(t => t.FormNameSpace)
                .HasMaxLength(100);

            this.Property(t => t.FormCaption)
                .HasMaxLength(50);

            this.Property(t => t.KeyFieldName)
                .HasMaxLength(50);

            this.Property(t => t.Table1)
                .HasMaxLength(50);

            this.Property(t => t.Table1Name)
                .HasMaxLength(50);

            this.Property(t => t.Table2)
                .HasMaxLength(50);

            this.Property(t => t.Table2Name)
                .HasMaxLength(50);

            this.Property(t => t.Table3)
                .HasMaxLength(50);

            this.Property(t => t.Table3Name)
                .HasMaxLength(50);

            this.Property(t => t.Table4)
                .HasMaxLength(50);

            this.Property(t => t.Table4Name)
                .HasMaxLength(50);

            this.Property(t => t.Table5)
                .HasMaxLength(50);

            this.Property(t => t.Table5Name)
                .HasMaxLength(50);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_CompanyInfoMap : EntityTypeConfiguration<tb_CompanyInfo>
    {
        public tb_CompanyInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.CompanyCode);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CompanyCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.NativeName)
                .HasMaxLength(40);

            this.Property(t => t.EnglishName)
                .HasMaxLength(40);

            this.Property(t => t.ProgramName)
                .HasMaxLength(40);

            this.Property(t => t.ReportHead)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            this.Property(t => t.Tel)
                .HasMaxLength(50);

            this.Property(t => t.Fax)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(20);

        }
    }
}

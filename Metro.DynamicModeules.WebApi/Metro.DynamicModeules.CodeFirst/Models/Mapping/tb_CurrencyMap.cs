using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_CurrencyMap : EntityTypeConfiguration<tb_Currency>
    {
        public tb_CurrencyMap()
        {
            // Primary Key
            this.HasKey(t => t.Currency);

            // Properties
            this.Property(t => t.isid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Currency)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CurrencyName)
                .HasMaxLength(20);

        }
    }
}

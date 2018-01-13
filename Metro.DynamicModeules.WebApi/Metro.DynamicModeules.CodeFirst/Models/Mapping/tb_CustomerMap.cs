using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.CodeFirst.Models.Mapping
{
    public class tb_CustomerMap : EntityTypeConfiguration<tb_Customer>
    {
        public tb_CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerCode);

            // Properties
            this.Property(t => t.ISID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CustomerCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.NativeName)
                .HasMaxLength(100);

            this.Property(t => t.EnglishName)
                .HasMaxLength(100);

            this.Property(t => t.AttributeCodes)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.Address3)
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .HasMaxLength(20);

            this.Property(t => t.Region)
                .HasMaxLength(20);

            this.Property(t => t.City)
                .HasMaxLength(20);

            this.Property(t => t.CountryCode)
                .HasMaxLength(6);

            this.Property(t => t.CityCode)
                .HasMaxLength(6);

            this.Property(t => t.Tel)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.PostalCode)
                .HasMaxLength(20);

            this.Property(t => t.ZipCode)
                .HasMaxLength(20);

            this.Property(t => t.WebAddress)
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(200);

            this.Property(t => t.Bank)
                .HasMaxLength(20);

            this.Property(t => t.BankAccount)
                .HasMaxLength(50);

            this.Property(t => t.BankAddress)
                .HasMaxLength(50);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(20);

            this.Property(t => t.Remark)
                .HasMaxLength(200);

            this.Property(t => t.InUse)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.LastUpdatedBy)
                .HasMaxLength(50);

        }
    }
}

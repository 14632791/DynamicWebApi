namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string CustomerCode { get; set; }

        [StringLength(100)]
        public string NativeName { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [StringLength(50)]
        public string AttributeCodes { get; set; }

        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string Address3 { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [StringLength(20)]
        public string Region { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(6)]
        public string CountryCode { get; set; }

        [StringLength(6)]
        public string CityCode { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(200)]
        public string WebAddress { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Bank { get; set; }

        [StringLength(50)]
        public string BankAccount { get; set; }

        [StringLength(50)]
        public string BankAddress { get; set; }

        [StringLength(20)]
        public string ContactPerson { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [StringLength(10)]
        public string InUse { get; set; }

        public int? PaymentTerm { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
    }
}

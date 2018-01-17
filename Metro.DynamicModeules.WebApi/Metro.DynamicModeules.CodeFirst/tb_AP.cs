namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_AP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string APNO { get; set; }

        public DateTime? ReceivedDate { get; set; }

        [StringLength(20)]
        public string SupplierCode { get; set; }

        [StringLength(20)]
        public string ChequeNo { get; set; }

        [StringLength(20)]
        public string ChequeBank { get; set; }

        [StringLength(20)]
        public string Currency { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }

        [StringLength(1)]
        public string FlagApp { get; set; }

        [StringLength(20)]
        public string AppUser { get; set; }

        public DateTime? AppDate { get; set; }
    }
}

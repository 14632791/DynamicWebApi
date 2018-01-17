namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ARs
    {
        [Key]
        public int ISID { get; set; }

        [StringLength(20)]
        public string ARNO { get; set; }

        public decimal? Queue { get; set; }

        [StringLength(20)]
        public string InvoiceNo { get; set; }

        [StringLength(20)]
        public string SONO { get; set; }

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
    }
}

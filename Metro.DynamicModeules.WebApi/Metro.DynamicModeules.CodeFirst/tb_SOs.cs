namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SOs
    {
        [Key]
        public int ISID { get; set; }

        [Required]
        [StringLength(20)]
        public string SONO { get; set; }

        public decimal Queue { get; set; }

        [Required]
        [StringLength(20)]
        public string StockCode { get; set; }

        [StringLength(50)]
        public string CustomerOrderNo { get; set; }

        public DateTime? ShipDay { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public int? Qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }

        public virtual tb_SO tb_SO { get; set; }
    }
}

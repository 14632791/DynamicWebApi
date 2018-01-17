namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_PO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string PONO { get; set; }

        public DateTime? PODate { get; set; }

        [StringLength(20)]
        public string POUser { get; set; }

        [StringLength(20)]
        public string CustomerCode { get; set; }

        [StringLength(20)]
        public string CustomerContact { get; set; }

        [StringLength(20)]
        public string CustomerTel { get; set; }

        [StringLength(10)]
        public string PayType { get; set; }

        [StringLength(20)]
        public string CustomerOrderNo { get; set; }

        [StringLength(4)]
        public string Currency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(50)]
        public string LastUpdatedBy { get; set; }

        [StringLength(1)]
        public string FlagApp { get; set; }

        [StringLength(20)]
        public string AppUser { get; set; }

        public DateTime? AppDate { get; set; }
    }
}

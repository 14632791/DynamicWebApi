namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_POs
    {
        [Key]
        public int ISID { get; set; }

        [Required]
        [StringLength(20)]
        public string PONO { get; set; }

        public decimal Queue { get; set; }

        [Required]
        [StringLength(20)]
        public string ProductCode { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public int? Quantity { get; set; }

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
    }
}

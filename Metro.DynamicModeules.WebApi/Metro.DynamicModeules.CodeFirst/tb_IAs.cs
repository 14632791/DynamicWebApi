namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_IAs
    {
        [Key]
        public int ISID { get; set; }

        public decimal? Queue { get; set; }

        [Required]
        [StringLength(20)]
        public string IANO { get; set; }

        [Required]
        [StringLength(20)]
        public string ProductCode { get; set; }

        public int? Quantity { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string LocationID { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }
    }
}

namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int isid { get; set; }

        [Key]
        [StringLength(20)]
        public string ProductCode { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(20)]
        public string CategoryId { get; set; }

        public decimal? SellPrice { get; set; }

        [StringLength(50)]
        public string Supplier { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}

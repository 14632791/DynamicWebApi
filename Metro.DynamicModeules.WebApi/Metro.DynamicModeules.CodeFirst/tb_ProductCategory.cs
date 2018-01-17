namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int isid { get; set; }

        [Key]
        [StringLength(20)]
        public string CategoryId { get; set; }

        [StringLength(20)]
        public string ParentId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string Column1 { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }
    }
}

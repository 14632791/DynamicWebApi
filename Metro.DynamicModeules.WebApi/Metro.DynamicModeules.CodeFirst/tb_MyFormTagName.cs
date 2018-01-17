namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyFormTagName
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AUID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MenuName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagValue { get; set; }

        [StringLength(20)]
        public string TagName { get; set; }
    }
}

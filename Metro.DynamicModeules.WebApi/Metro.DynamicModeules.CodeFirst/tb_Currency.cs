namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Currency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int isid { get; set; }

        [Key]
        [StringLength(10)]
        public string Currency { get; set; }

        [StringLength(20)]
        public string CurrencyName { get; set; }
    }
}

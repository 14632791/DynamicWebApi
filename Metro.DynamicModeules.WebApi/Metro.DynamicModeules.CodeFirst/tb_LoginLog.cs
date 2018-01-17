namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_LoginLog
    {
        [Key]
        public int isid { get; set; }

        [StringLength(20)]
        public string Account { get; set; }

        [StringLength(1)]
        public string LoginType { get; set; }

        public DateTime? CurrentTime { get; set; }
    }
}

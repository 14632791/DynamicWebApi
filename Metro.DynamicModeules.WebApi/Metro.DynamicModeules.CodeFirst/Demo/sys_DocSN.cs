namespace Metro.DynamicModeules.CodeFirst.Demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_DocSN
    {
        [Key]
        public int isid { get; set; }

        [StringLength(10)]
        public string DocName { get; set; }

        [StringLength(2)]
        public string Header { get; set; }

        [StringLength(4)]
        public string YYMM { get; set; }

        public int? MaxID { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}

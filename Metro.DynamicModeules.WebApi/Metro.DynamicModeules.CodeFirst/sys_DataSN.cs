namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_DataSN
    {
        [Key]
        public int isid { get; set; }

        [StringLength(10)]
        public string DataCode { get; set; }

        [StringLength(10)]
        public string Header { get; set; }

        public int? Length { get; set; }

        public int? MaxID { get; set; }
    }
}

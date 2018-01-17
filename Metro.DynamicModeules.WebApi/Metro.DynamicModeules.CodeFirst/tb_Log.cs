namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Log
    {
        [Key]
        public int isid { get; set; }

        [StringLength(32)]
        public string GUID32 { get; set; }

        [Required]
        [StringLength(30)]
        public string LogUser { get; set; }

        public DateTime LogDate { get; set; }

        public int OPType { get; set; }

        [StringLength(30)]
        public string TableName { get; set; }

        [StringLength(20)]
        public string KeyFieldName { get; set; }

        [StringLength(20)]
        public string DocNo { get; set; }

        [StringLength(1)]
        public string IsMaster { get; set; }
    }
}

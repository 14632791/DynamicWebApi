namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_LogDtl
    {
        [Key]
        public int isid { get; set; }

        [StringLength(32)]
        public string GUID32 { get; set; }

        [StringLength(20)]
        public string TableName { get; set; }

        [StringLength(20)]
        public string FieldName { get; set; }

        [StringLength(250)]
        public string OldValue { get; set; }

        [StringLength(250)]
        public string NewValue { get; set; }
    }
}

namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_FieldNameDefs
    {
        [Key]
        public int isid { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [StringLength(50)]
        public string FieldName { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        [StringLength(1)]
        public string FlagDisplay { get; set; }
    }
}

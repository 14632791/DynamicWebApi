namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CommDataDictType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int isid { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DataType { get; set; }

        [StringLength(20)]
        public string TypeName { get; set; }
    }
}

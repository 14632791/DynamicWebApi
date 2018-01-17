namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserGroup
    {
        [Key]
        public int isid { get; set; }

        [StringLength(30)]
        public string GroupCode { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }
    }
}

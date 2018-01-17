namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserGroupRe
    {
        [Key]
        public int isid { get; set; }

        [Required]
        [StringLength(30)]
        public string GroupCode { get; set; }

        [Required]
        [StringLength(30)]
        public string Account { get; set; }
    }
}

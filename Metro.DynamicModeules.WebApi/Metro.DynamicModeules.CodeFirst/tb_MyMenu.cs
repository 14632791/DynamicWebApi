namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyMenu
    {
        [Key]
        public int isid { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuName { get; set; }

        [StringLength(50)]
        public string MenuCaption { get; set; }

        public int? Auths { get; set; }

        public int? ModuleID { get; set; }

        [Required]
        [StringLength(20)]
        public string MenuType { get; set; }
    }
}

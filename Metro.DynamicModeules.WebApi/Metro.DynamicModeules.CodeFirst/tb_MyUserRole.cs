namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserRole
    {
        [Key]
        public int isid { get; set; }

        [StringLength(30)]
        public string GroupCode { get; set; }

        public int? ModuleID { get; set; }

        [StringLength(50)]
        public string AuthorityID { get; set; }

        public int? Authorities { get; set; }
    }
}

namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserGroupRe
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string GroupCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Account { get; set; }
    }
}

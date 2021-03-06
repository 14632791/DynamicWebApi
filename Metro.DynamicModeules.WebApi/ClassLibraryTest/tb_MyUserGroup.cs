namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserGroup
    {
        [Key]
        [StringLength(30)]
        public string GroupCode { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
    }
}

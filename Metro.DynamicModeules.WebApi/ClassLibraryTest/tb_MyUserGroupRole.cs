namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserGroupRole
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string GroupCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId { get; set; }

        public int Authorities { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        [StringLength(50)]
        public string LastUpdatedBy { get; set; }

        public virtual tb_MyMenu tb_MyMenu { get; set; }

        public virtual tb_MyUserGroup tb_MyUserGroup { get; set; }
    }
}

namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUserGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MyUserGroup()
        {
            tb_MyUserGroupRole = new HashSet<tb_MyUserGroupRole>();
            tb_MyUser = new HashSet<tb_MyUser>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyUserGroupRole> tb_MyUserGroupRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyUser> tb_MyUser { get; set; }
    }
}

namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MyMenu()
        {
            tb_MyUserGroupRole = new HashSet<tb_MyUserGroupRole>();
            tb_MyAuthorityItem = new HashSet<tb_MyAuthorityItem>();
        }

        [Key]
        public int isid { get; set; }

        [StringLength(50)]
        public string MenuName { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuCaption { get; set; }

        public int Authorities { get; set; }

        public int ModuleID { get; set; }

        [Required]
        [StringLength(20)]
        public string MenuType { get; set; }

        public virtual sys_Modules sys_Modules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyUserGroupRole> tb_MyUserGroupRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyAuthorityItem> tb_MyAuthorityItem { get; set; }
    }
}

namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MyUser()
        {
            tb_MyUserGroup = new HashSet<tb_MyUserGroup>();
        }

        [Key]
        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(100)]
        public string NovellAccount { get; set; }

        [StringLength(100)]
        public string DomainName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime? LastLogoutTime { get; set; }

        public short? IsLocked { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(1)]
        public string FlagAdmin { get; set; }

        [StringLength(1)]
        public string FlagOnline { get; set; }

        public int? LoginCounter { get; set; }

        [StringLength(250)]
        public string DataSets { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        [StringLength(50)]
        public string LastUpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyUserGroup> tb_MyUserGroup { get; set; }
    }
}

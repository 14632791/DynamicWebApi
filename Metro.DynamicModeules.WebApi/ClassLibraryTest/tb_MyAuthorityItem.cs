namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyAuthorityItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MyAuthorityItem()
        {
            tb_MyMenu = new HashSet<tb_MyMenu>();
        }

        [Key]
        public int isid { get; set; }

        [StringLength(20)]
        public string AuthorityName { get; set; }

        public int? AuthorityValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyMenu> tb_MyMenu { get; set; }
    }
}

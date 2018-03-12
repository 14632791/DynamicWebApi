namespace ClassLibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MyAuthorityItem
    {
        [Key]
        public int isid { get; set; }

        [StringLength(20)]
        public string AuthorityName { get; set; }

        public int? AuthorityValue { get; set; }
    }
}

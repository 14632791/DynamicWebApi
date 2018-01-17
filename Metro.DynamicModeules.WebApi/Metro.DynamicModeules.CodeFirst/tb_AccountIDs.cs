namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_AccountIDs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string AccID { get; set; }

        [StringLength(50)]
        public string AccName { get; set; }
    }
}

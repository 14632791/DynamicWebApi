namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CommonDataDict
    {
        [Key]
        public int ISID { get; set; }

        public int? DataType { get; set; }

        [StringLength(20)]
        public string DataCode { get; set; }

        [StringLength(100)]
        public string NativeName { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }
    }
}

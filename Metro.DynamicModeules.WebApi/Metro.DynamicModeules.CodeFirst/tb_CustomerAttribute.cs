namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CustomerAttribute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(10)]
        public string AttributeCode { get; set; }

        [StringLength(40)]
        public string NativeName { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }

        [StringLength(10)]
        public string IsSelected { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }
    }
}

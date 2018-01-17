namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_IA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string IANO { get; set; }

        public DateTime? DocDate { get; set; }

        [StringLength(20)]
        public string DocUser { get; set; }

        [StringLength(200)]
        public string Reason { get; set; }

        [StringLength(1)]
        public string FlagApp { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string AppUser { get; set; }

        public DateTime? AppDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}

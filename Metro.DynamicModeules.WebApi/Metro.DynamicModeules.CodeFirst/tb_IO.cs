namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_IO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string IONO { get; set; }

        public DateTime? DocDate { get; set; }

        [StringLength(20)]
        public string DocUser { get; set; }

        [StringLength(20)]
        public string RefNo { get; set; }

        [StringLength(20)]
        public string CustomerCode { get; set; }

        [StringLength(20)]
        public string Department { get; set; }

        [StringLength(20)]
        public string Deliver { get; set; }

        [StringLength(20)]
        public string LocationID { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(1)]
        public string FlagApp { get; set; }

        [StringLength(20)]
        public string AppUser { get; set; }

        public DateTime? AppDate { get; set; }

        [StringLength(20)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}

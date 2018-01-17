namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_SO()
        {
            tb_SOs = new HashSet<tb_SOs>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ISID { get; set; }

        [Key]
        [StringLength(20)]
        public string SONO { get; set; }

        [StringLength(2)]
        public string VerNo { get; set; }

        [StringLength(20)]
        public string CustomerCode { get; set; }

        public DateTime? ReceiveDay { get; set; }

        [StringLength(10)]
        public string PayType { get; set; }

        [StringLength(20)]
        public string CustomerOrderNo { get; set; }

        [StringLength(20)]
        public string Salesman { get; set; }

        [StringLength(4)]
        public string Currency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [StringLength(10)]
        public string FinishingStatus { get; set; }

        public DateTime? OrderFinishDay { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(50)]
        public string LastUpdatedBy { get; set; }

        [StringLength(1)]
        public string FlagApp { get; set; }

        [StringLength(20)]
        public string AppUser { get; set; }

        public DateTime? AppDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SOs> tb_SOs { get; set; }
    }
}

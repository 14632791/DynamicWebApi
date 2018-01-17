namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_AttachFile
    {
        [Key]
        public int FileID { get; set; }

        [StringLength(20)]
        public string DocID { get; set; }

        [Required]
        [StringLength(100)]
        public string FileTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        [StringLength(10)]
        public string FileType { get; set; }

        public decimal? FileSize { get; set; }

        [Column(TypeName = "image")]
        public byte[] FileBody { get; set; }

        [StringLength(1)]
        public string IsDroped { get; set; }
    }
}

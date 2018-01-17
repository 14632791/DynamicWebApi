namespace Metro.DynamicModeules.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_BusinessTables
    {
        [Key]
        public int isid { get; set; }

        public int? ModuleID { get; set; }

        public int? SortID { get; set; }

        [StringLength(50)]
        public string FormName { get; set; }

        [StringLength(100)]
        public string FormNameSpace { get; set; }

        [StringLength(50)]
        public string FormCaption { get; set; }

        [StringLength(50)]
        public string KeyFieldName { get; set; }

        [StringLength(50)]
        public string Table1 { get; set; }

        [StringLength(50)]
        public string Table1Name { get; set; }

        [StringLength(50)]
        public string Table2 { get; set; }

        [StringLength(50)]
        public string Table2Name { get; set; }

        [StringLength(50)]
        public string Table3 { get; set; }

        [StringLength(50)]
        public string Table3Name { get; set; }

        [StringLength(50)]
        public string Table4 { get; set; }

        [StringLength(50)]
        public string Table4Name { get; set; }

        [StringLength(50)]
        public string Table5 { get; set; }

        [StringLength(50)]
        public string Table5Name { get; set; }
    }
}

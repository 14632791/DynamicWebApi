namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Location")]
    public partial class tb_Location: INotifyPropertyChanged
    {
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
[Column("ISID")]
        public int ISID 
		{ 
		   get
           {
               return _ISID;
           }
           set
           {
               if (Equals(_ISID, value)) return;
               _ISID = value;
               RaisePropertyChanged("ISID");
           }
		} 
		private int _ISID;
[Column("LocationID")]
 [Key]
        [StringLength(20)]
        public string LocationID 
		{ 
		   get
           {
               return _LocationID;
           }
           set
           {
               if (Equals(_LocationID, value)) return;
               _LocationID = value;
               RaisePropertyChanged("LocationID");
           }
		} 
		private string _LocationID;
[Column("LocationName")]
 [StringLength(50)]
        public string LocationName 
		{ 
		   get
           {
               return _LocationName;
           }
           set
           {
               if (Equals(_LocationName, value)) return;
               _LocationName = value;
               RaisePropertyChanged("LocationName");
           }
		} 
		private string _LocationName;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

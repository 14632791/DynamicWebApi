using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_IAs")]
    public partial class tb_IAs: INotifyPropertyChanged
    {
	
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
[Column("Queue")]
        public Nullable<decimal> Queue 
		{ 
		   get
           {
               return _Queue;
           }
           set
           {
               if (Equals(_Queue, value)) return;
               _Queue = value;
               RaisePropertyChanged("Queue");
           }
		} 
		private Nullable<decimal> _Queue;
[Column("IANO")]
        public string IANO 
		{ 
		   get
           {
               return _IANO;
           }
           set
           {
               if (Equals(_IANO, value)) return;
               _IANO = value;
               RaisePropertyChanged("IANO");
           }
		} 
		private string _IANO;
[Column("ProductCode")]
        public string ProductCode 
		{ 
		   get
           {
               return _ProductCode;
           }
           set
           {
               if (Equals(_ProductCode, value)) return;
               _ProductCode = value;
               RaisePropertyChanged("ProductCode");
           }
		} 
		private string _ProductCode;
[Column("Quantity")]
        public Nullable<int> Quantity 
		{ 
		   get
           {
               return _Quantity;
           }
           set
           {
               if (Equals(_Quantity, value)) return;
               _Quantity = value;
               RaisePropertyChanged("Quantity");
           }
		} 
		private Nullable<int> _Quantity;
[Column("Remark")]
        public string Remark 
		{ 
		   get
           {
               return _Remark;
           }
           set
           {
               if (Equals(_Remark, value)) return;
               _Remark = value;
               RaisePropertyChanged("Remark");
           }
		} 
		private string _Remark;
[Column("LocationID")]
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
[Column("CreationDate")]
        public Nullable<System.DateTime> CreationDate 
		{ 
		   get
           {
               return _CreationDate;
           }
           set
           {
               if (Equals(_CreationDate, value)) return;
               _CreationDate = value;
               RaisePropertyChanged("CreationDate");
           }
		} 
		private Nullable<System.DateTime> _CreationDate;
[Column("CreatedBy")]
        public string CreatedBy 
		{ 
		   get
           {
               return _CreatedBy;
           }
           set
           {
               if (Equals(_CreatedBy, value)) return;
               _CreatedBy = value;
               RaisePropertyChanged("CreatedBy");
           }
		} 
		private string _CreatedBy;
[Column("LastUpdateDate")]
        public Nullable<System.DateTime> LastUpdateDate 
		{ 
		   get
           {
               return _LastUpdateDate;
           }
           set
           {
               if (Equals(_LastUpdateDate, value)) return;
               _LastUpdateDate = value;
               RaisePropertyChanged("LastUpdateDate");
           }
		} 
		private Nullable<System.DateTime> _LastUpdateDate;
[Column("LastUpdatedBy")]
        public string LastUpdatedBy 
		{ 
		   get
           {
               return _LastUpdatedBy;
           }
           set
           {
               if (Equals(_LastUpdatedBy, value)) return;
               _LastUpdatedBy = value;
               RaisePropertyChanged("LastUpdatedBy");
           }
		} 
		private string _LastUpdatedBy;
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

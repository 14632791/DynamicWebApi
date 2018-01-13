using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_SO")]
    public partial class tb_SO: INotifyPropertyChanged
    {
	
        public tb_SO()
        {
            this.tb_SOs = new List<tb_SOs>();
        }

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
[Column("SONO")]
        public string SONO 
		{ 
		   get
           {
               return _SONO;
           }
           set
           {
               if (Equals(_SONO, value)) return;
               _SONO = value;
               RaisePropertyChanged("SONO");
           }
		} 
		private string _SONO;
[Column("VerNo")]
        public string VerNo 
		{ 
		   get
           {
               return _VerNo;
           }
           set
           {
               if (Equals(_VerNo, value)) return;
               _VerNo = value;
               RaisePropertyChanged("VerNo");
           }
		} 
		private string _VerNo;
[Column("CustomerCode")]
        public string CustomerCode 
		{ 
		   get
           {
               return _CustomerCode;
           }
           set
           {
               if (Equals(_CustomerCode, value)) return;
               _CustomerCode = value;
               RaisePropertyChanged("CustomerCode");
           }
		} 
		private string _CustomerCode;
[Column("ReceiveDay")]
        public Nullable<System.DateTime> ReceiveDay 
		{ 
		   get
           {
               return _ReceiveDay;
           }
           set
           {
               if (Equals(_ReceiveDay, value)) return;
               _ReceiveDay = value;
               RaisePropertyChanged("ReceiveDay");
           }
		} 
		private Nullable<System.DateTime> _ReceiveDay;
[Column("PayType")]
        public string PayType 
		{ 
		   get
           {
               return _PayType;
           }
           set
           {
               if (Equals(_PayType, value)) return;
               _PayType = value;
               RaisePropertyChanged("PayType");
           }
		} 
		private string _PayType;
[Column("CustomerOrderNo")]
        public string CustomerOrderNo 
		{ 
		   get
           {
               return _CustomerOrderNo;
           }
           set
           {
               if (Equals(_CustomerOrderNo, value)) return;
               _CustomerOrderNo = value;
               RaisePropertyChanged("CustomerOrderNo");
           }
		} 
		private string _CustomerOrderNo;
[Column("Salesman")]
        public string Salesman 
		{ 
		   get
           {
               return _Salesman;
           }
           set
           {
               if (Equals(_Salesman, value)) return;
               _Salesman = value;
               RaisePropertyChanged("Salesman");
           }
		} 
		private string _Salesman;
[Column("Currency")]
        public string Currency 
		{ 
		   get
           {
               return _Currency;
           }
           set
           {
               if (Equals(_Currency, value)) return;
               _Currency = value;
               RaisePropertyChanged("Currency");
           }
		} 
		private string _Currency;
[Column("Amount")]
        public Nullable<decimal> Amount 
		{ 
		   get
           {
               return _Amount;
           }
           set
           {
               if (Equals(_Amount, value)) return;
               _Amount = value;
               RaisePropertyChanged("Amount");
           }
		} 
		private Nullable<decimal> _Amount;
[Column("FinishingStatus")]
        public string FinishingStatus 
		{ 
		   get
           {
               return _FinishingStatus;
           }
           set
           {
               if (Equals(_FinishingStatus, value)) return;
               _FinishingStatus = value;
               RaisePropertyChanged("FinishingStatus");
           }
		} 
		private string _FinishingStatus;
[Column("OrderFinishDay")]
        public Nullable<System.DateTime> OrderFinishDay 
		{ 
		   get
           {
               return _OrderFinishDay;
           }
           set
           {
               if (Equals(_OrderFinishDay, value)) return;
               _OrderFinishDay = value;
               RaisePropertyChanged("OrderFinishDay");
           }
		} 
		private Nullable<System.DateTime> _OrderFinishDay;
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
[Column("FlagApp")]
        public string FlagApp 
		{ 
		   get
           {
               return _FlagApp;
           }
           set
           {
               if (Equals(_FlagApp, value)) return;
               _FlagApp = value;
               RaisePropertyChanged("FlagApp");
           }
		} 
		private string _FlagApp;
[Column("AppUser")]
        public string AppUser 
		{ 
		   get
           {
               return _AppUser;
           }
           set
           {
               if (Equals(_AppUser, value)) return;
               _AppUser = value;
               RaisePropertyChanged("AppUser");
           }
		} 
		private string _AppUser;
[Column("AppDate")]
        public Nullable<System.DateTime> AppDate 
		{ 
		   get
           {
               return _AppDate;
           }
           set
           {
               if (Equals(_AppDate, value)) return;
               _AppDate = value;
               RaisePropertyChanged("AppDate");
           }
		} 
		private Nullable<System.DateTime> _AppDate;
        public virtual ICollection<tb_SOs> tb_SOs 
		{ 
		   get
           {
               return _tb_SOs;
           }
           set
           {
               if (Equals(_tb_SOs, value)) return;
               _tb_SOs = value;
               RaisePropertyChanged("tb_SOs");
           }
		}
		protected ICollection<tb_SOs> _tb_SOs; 
      
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

namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_MyUser")]
    public partial class tb_MyUser: INotifyPropertyChanged
    {
	  [Key]
[Column("isid")]
        public int isid 
		{ 
		   get
           {
               return _isid;
           }
           set
           {
               if (Equals(_isid, value)) return;
               _isid = value;
               RaisePropertyChanged("isid");
           }
		} 
		private int _isid;
[Column("Account")]
 [Required]
        [StringLength(30)]
        public string Account 
		{ 
		   get
           {
               return _Account;
           }
           set
           {
               if (Equals(_Account, value)) return;
               _Account = value;
               RaisePropertyChanged("Account");
           }
		} 
		private string _Account;
[Column("NovellAccount")]
[StringLength(100)]
        public string NovellAccount 
		{ 
		   get
           {
               return _NovellAccount;
           }
           set
           {
               if (Equals(_NovellAccount, value)) return;
               _NovellAccount = value;
               RaisePropertyChanged("NovellAccount");
           }
		} 
		private string _NovellAccount;
[Column("DomainName")]
[StringLength(100)]
        public string DomainName 
		{ 
		   get
           {
               return _DomainName;
           }
           set
           {
               if (Equals(_DomainName, value)) return;
               _DomainName = value;
               RaisePropertyChanged("DomainName");
           }
		} 
		private string _DomainName;
[Column("UserName")]
 [Required]
        [StringLength(20)]
        public string UserName 
		{ 
		   get
           {
               return _UserName;
           }
           set
           {
               if (Equals(_UserName, value)) return;
               _UserName = value;
               RaisePropertyChanged("UserName");
           }
		} 
		private string _UserName;
[Column("Address")]
[StringLength(50)]
        public string Address 
		{ 
		   get
           {
               return _Address;
           }
           set
           {
               if (Equals(_Address, value)) return;
               _Address = value;
               RaisePropertyChanged("Address");
           }
		} 
		private string _Address;
[Column("Tel")]
[StringLength(50)]
        public string Tel 
		{ 
		   get
           {
               return _Tel;
           }
           set
           {
               if (Equals(_Tel, value)) return;
               _Tel = value;
               RaisePropertyChanged("Tel");
           }
		} 
		private string _Tel;
[Column("Email")]
[StringLength(40)]
        public string Email 
		{ 
		   get
           {
               return _Email;
           }
           set
           {
               if (Equals(_Email, value)) return;
               _Email = value;
               RaisePropertyChanged("Email");
           }
		} 
		private string _Email;
[Column("Password")]
 [StringLength(100)]
        public string Password 
		{ 
		   get
           {
               return _Password;
           }
           set
           {
               if (Equals(_Password, value)) return;
               _Password = value;
               RaisePropertyChanged("Password");
           }
		} 
		private string _Password;
[Column("LastLoginTime")]
        public Nullable<System.DateTime> LastLoginTime 
		{ 
		   get
           {
               return _LastLoginTime;
           }
           set
           {
               if (Equals(_LastLoginTime, value)) return;
               _LastLoginTime = value;
               RaisePropertyChanged("LastLoginTime");
           }
		} 
		private Nullable<System.DateTime> _LastLoginTime;
[Column("LastLogoutTime")]
        public Nullable<System.DateTime> LastLogoutTime 
		{ 
		   get
           {
               return _LastLogoutTime;
           }
           set
           {
               if (Equals(_LastLogoutTime, value)) return;
               _LastLogoutTime = value;
               RaisePropertyChanged("LastLogoutTime");
           }
		} 
		private Nullable<System.DateTime> _LastLogoutTime;
[Column("IsLocked")]
        public Nullable<short> IsLocked 
		{ 
		   get
           {
               return _IsLocked;
           }
           set
           {
               if (Equals(_IsLocked, value)) return;
               _IsLocked = value;
               RaisePropertyChanged("IsLocked");
           }
		} 
		private Nullable<short> _IsLocked;
[Column("CreateTime")]
        public Nullable<System.DateTime> CreateTime 
		{ 
		   get
           {
               return _CreateTime;
           }
           set
           {
               if (Equals(_CreateTime, value)) return;
               _CreateTime = value;
               RaisePropertyChanged("CreateTime");
           }
		} 
		private Nullable<System.DateTime> _CreateTime;
[Column("FlagAdmin")]
 [StringLength(1)]
        public string FlagAdmin 
		{ 
		   get
           {
               return _FlagAdmin;
           }
           set
           {
               if (Equals(_FlagAdmin, value)) return;
               _FlagAdmin = value;
               RaisePropertyChanged("FlagAdmin");
           }
		} 
		private string _FlagAdmin;
[Column("FlagOnline")]
        public string FlagOnline 
		{ 
		   get
           {
               return _FlagOnline;
           }
           set
           {
               if (Equals(_FlagOnline, value)) return;
               _FlagOnline = value;
               RaisePropertyChanged("FlagOnline");
           }
		} 
		private string _FlagOnline;
[Column("LoginCounter")]
        public Nullable<int> LoginCounter 
		{ 
		   get
           {
               return _LoginCounter;
           }
           set
           {
               if (Equals(_LoginCounter, value)) return;
               _LoginCounter = value;
               RaisePropertyChanged("LoginCounter");
           }
		} 
		private Nullable<int> _LoginCounter;
[Column("DataSets")]
        public string DataSets 
		{ 
		   get
           {
               return _DataSets;
           }
           set
           {
               if (Equals(_DataSets, value)) return;
               _DataSets = value;
               RaisePropertyChanged("DataSets");
           }
		} 
		private string _DataSets;
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

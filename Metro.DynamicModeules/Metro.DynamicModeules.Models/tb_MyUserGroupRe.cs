using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_MyUserGroupRe")]
    public partial class tb_MyUserGroupRe: INotifyPropertyChanged
    {
	
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
[Column("GroupCode")]
        public string GroupCode 
		{ 
		   get
           {
               return _GroupCode;
           }
           set
           {
               if (Equals(_GroupCode, value)) return;
               _GroupCode = value;
               RaisePropertyChanged("GroupCode");
           }
		} 
		private string _GroupCode;
[Column("Account")]
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

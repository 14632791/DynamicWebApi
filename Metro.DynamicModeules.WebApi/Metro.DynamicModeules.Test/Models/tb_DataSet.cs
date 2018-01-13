using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Metro.DynamicModeules.Test.Models
{
    public partial class tb_DataSet: INotifyPropertyChanged
    {
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
		int _isid;
        public string DataSetID 
		{ 
		   get
           {
               return _DataSetID;
           }
           set
           {
               if (Equals(_DataSetID, value)) return;
               _DataSetID = value;
               RaisePropertyChanged("DataSetID");
           }
		} 
		string _DataSetID;
        public string DataSetName 
		{ 
		   get
           {
               return _DataSetName;
           }
           set
           {
               if (Equals(_DataSetName, value)) return;
               _DataSetName = value;
               RaisePropertyChanged("DataSetName");
           }
		} 
		string _DataSetName;
        public string ServerIP 
		{ 
		   get
           {
               return _ServerIP;
           }
           set
           {
               if (Equals(_ServerIP, value)) return;
               _ServerIP = value;
               RaisePropertyChanged("ServerIP");
           }
		} 
		string _ServerIP;
        public string DBName 
		{ 
		   get
           {
               return _DBName;
           }
           set
           {
               if (Equals(_DBName, value)) return;
               _DBName = value;
               RaisePropertyChanged("DBName");
           }
		} 
		string _DBName;
        public string DBUserName 
		{ 
		   get
           {
               return _DBUserName;
           }
           set
           {
               if (Equals(_DBUserName, value)) return;
               _DBUserName = value;
               RaisePropertyChanged("DBUserName");
           }
		} 
		string _DBUserName;
        public string DBUserPassword 
		{ 
		   get
           {
               return _DBUserPassword;
           }
           set
           {
               if (Equals(_DBUserPassword, value)) return;
               _DBUserPassword = value;
               RaisePropertyChanged("DBUserPassword");
           }
		} 
		string _DBUserPassword;
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
		string _Remark;
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

namespace Metro.DynamicModeules.Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Metro.DynamicModeules.Models;

    public partial class NormalEntity : DbContext
    {
        public NormalEntity()
            : base("name=NormalEntity")
        {
        }

       // public virtual DbSet<dtproperties> dtproperties { get; set; }
        public virtual DbSet<sys_BusinessTables> sys_BusinessTables { get; set; }
        public virtual DbSet<sys_DataSN> sys_DataSN { get; set; }
        public virtual DbSet<sys_DocSN> sys_DocSN { get; set; }
        public virtual DbSet<sys_FieldNameDefs> sys_FieldNameDefs { get; set; }
        public virtual DbSet<sys_Modules> sys_Modules { get; set; }
        //public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tb_AccountIDs> tb_AccountIDs { get; set; }
        public virtual DbSet<tb_AP> tb_AP { get; set; }
        public virtual DbSet<tb_APs> tb_APs { get; set; }
        public virtual DbSet<tb_AR> tb_AR { get; set; }
        public virtual DbSet<tb_ARs> tb_ARs { get; set; }
        public virtual DbSet<tb_AttachFile> tb_AttachFile { get; set; }
        public virtual DbSet<tb_CommDataDictType> tb_CommDataDictType { get; set; }
        public virtual DbSet<tb_CommonDataDict> tb_CommonDataDict { get; set; }
        public virtual DbSet<tb_CompanyInfo> tb_CompanyInfo { get; set; }
        public virtual DbSet<tb_Currency> tb_Currency { get; set; }
        public virtual DbSet<tb_Customer> tb_Customer { get; set; }
        public virtual DbSet<tb_CustomerAttribute> tb_CustomerAttribute { get; set; }
        public virtual DbSet<tb_IA> tb_IA { get; set; }
        public virtual DbSet<tb_IAs> tb_IAs { get; set; }
        public virtual DbSet<tb_IC> tb_IC { get; set; }
        public virtual DbSet<tb_ICs> tb_ICs { get; set; }
        public virtual DbSet<tb_IN> tb_IN { get; set; }
        public virtual DbSet<tb_INs> tb_INs { get; set; }
        public virtual DbSet<tb_IO> tb_IO { get; set; }
        public virtual DbSet<tb_IOs> tb_IOs { get; set; }
        public virtual DbSet<tb_Location> tb_Location { get; set; }
        public virtual DbSet<tb_Log> tb_Log { get; set; }
        public virtual DbSet<tb_LogDtl> tb_LogDtl { get; set; }
        public virtual DbSet<tb_LogFields> tb_LogFields { get; set; }
        public virtual DbSet<tb_LoginLog> tb_LoginLog { get; set; }
        public virtual DbSet<tb_MyAuthorityItem> tb_MyAuthorityItem { get; set; }
        public virtual DbSet<tb_MyFormTagName> tb_MyFormTagName { get; set; }
        public virtual DbSet<tb_MyMenu> tb_MyMenu { get; set; }
        public virtual DbSet<tb_MyUser> tb_MyUser { get; set; }
        public virtual DbSet<tb_MyUserGroup> tb_MyUserGroup { get; set; }
        public virtual DbSet<tb_MyUserGroupRe> tb_MyUserGroupRe { get; set; }
        public virtual DbSet<tb_MyUserRole> tb_MyUserRole { get; set; }
        public virtual DbSet<tb_PayType> tb_PayType { get; set; }
        public virtual DbSet<tb_Person> tb_Person { get; set; }
        public virtual DbSet<tb_PO> tb_PO { get; set; }
        public virtual DbSet<tb_POs> tb_POs { get; set; }
        public virtual DbSet<tb_Product> tb_Product { get; set; }
        public virtual DbSet<tb_ProductCategory> tb_ProductCategory { get; set; }
        public virtual DbSet<tb_SO> tb_SO { get; set; }
        public virtual DbSet<tb_SOs> tb_SOs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<dtproperties>()
            //    .Property(e => e.property)
            //    .IsUnicode(false);

            //modelBuilder.Entity<dtproperties>()
            //    .Property(e => e.value)
            //    .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.FormName)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.FormNameSpace)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.KeyFieldName)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.Table1)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.Table2)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.Table3)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.Table4)
                .IsUnicode(false);

            modelBuilder.Entity<sys_BusinessTables>()
                .Property(e => e.Table5)
                .IsUnicode(false);

            modelBuilder.Entity<sys_DataSN>()
                .Property(e => e.DataCode)
                .IsUnicode(false);

            modelBuilder.Entity<sys_DataSN>()
                .Property(e => e.Header)
                .IsUnicode(false);

            modelBuilder.Entity<sys_DocSN>()
                .Property(e => e.DocName)
                .IsUnicode(false);

            modelBuilder.Entity<sys_DocSN>()
                .Property(e => e.Header)
                .IsUnicode(false);

            modelBuilder.Entity<sys_DocSN>()
                .Property(e => e.YYMM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sys_FieldNameDefs>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<sys_FieldNameDefs>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<sys_FieldNameDefs>()
                .Property(e => e.FlagDisplay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_AccountIDs>()
                .Property(e => e.AccID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.APNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.SupplierCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.ChequeNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.ChequeBank)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_AP>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_APs>()
                .Property(e => e.APNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_APs>()
                .Property(e => e.InvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_APs>()
                .Property(e => e.PONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_APs>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_APs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_APs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.ARNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.CustomerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.ChequeNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.ChequeBank)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_AR>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ARs>()
                .Property(e => e.ARNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ARs>()
                .Property(e => e.InvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ARs>()
                .Property(e => e.SONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ARs>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ARs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ARs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AttachFile>()
                .Property(e => e.DocID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AttachFile>()
                .Property(e => e.FileType)
                .IsUnicode(false);

            modelBuilder.Entity<tb_AttachFile>()
                .Property(e => e.IsDroped)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CommonDataDict>()
                .Property(e => e.DataCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CommonDataDict>()
                .Property(e => e.EnglishName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CommonDataDict>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CommonDataDict>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CompanyInfo>()
                .Property(e => e.CompanyCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_CompanyInfo>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CompanyInfo>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CompanyInfo>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CompanyInfo>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Currency>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Currency>()
                .Property(e => e.CurrencyName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.CustomerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.EnglishName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.AttributeCodes)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.CityCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.WebAddress)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.BankAccount)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.InUse)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Customer>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CustomerAttribute>()
                .Property(e => e.AttributeCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CustomerAttribute>()
                .Property(e => e.EnglishName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CustomerAttribute>()
                .Property(e => e.IsSelected)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_CustomerAttribute>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CustomerAttribute>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.IANO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.DocUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IA>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IAs>()
                .Property(e => e.IANO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IAs>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IAs>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IAs>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IAs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IAs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.ICNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.DocUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IC>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ICs>()
                .Property(e => e.ICNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ICs>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ICs>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ICs>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ICs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ICs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.INNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.DocUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.RefNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.SupplierCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.Deliver)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IN>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_INs>()
                .Property(e => e.INNO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_INs>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_INs>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_INs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_INs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.IONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.DocUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.RefNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.CustomerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.Deliver)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IO>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IOs>()
                .Property(e => e.IONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IOs>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IOs>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IOs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_IOs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Location>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Log>()
                .Property(e => e.GUID32)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Log>()
                .Property(e => e.LogUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Log>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Log>()
                .Property(e => e.KeyFieldName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Log>()
                .Property(e => e.DocNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Log>()
                .Property(e => e.IsMaster)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogDtl>()
                .Property(e => e.GUID32)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogDtl>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogDtl>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogDtl>()
                .Property(e => e.OldValue)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogDtl>()
                .Property(e => e.NewValue)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogFields>()
                .Property(e => e.TableName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LogFields>()
                .Property(e => e.FieldName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LoginLog>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<tb_LoginLog>()
                .Property(e => e.LoginType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyFormTagName>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyMenu>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyMenu>()
                .Property(e => e.MenuType)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.FlagAdmin)
                .IsFixedLength();

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.FlagOnline)
                .IsFixedLength();

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.DataSets)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroup>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroup>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRe>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRe>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserRole>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserRole>()
                .Property(e => e.AuthorityID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PayType>()
                .Property(e => e.PayType)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Person>()
                .Property(e => e.SalesCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Person>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Person>()
                .Property(e => e.InUse)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_Person>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Person>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.PONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.POUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.CustomerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.CustomerContact)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.CustomerTel)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.PayType)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.CustomerOrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_PO>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_POs>()
                .Property(e => e.PONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_POs>()
                .Property(e => e.Queue)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tb_POs>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_POs>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<tb_POs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_POs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Product>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Product>()
                .Property(e => e.Supplier)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Product>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ProductCategory>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<tb_ProductCategory>()
                .Property(e => e.ParentId)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.SONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.VerNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.CustomerCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.PayType)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.CustomerOrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.Salesman)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.FinishingStatus)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.FlagApp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .Property(e => e.AppUser)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SO>()
                .HasMany(e => e.tb_SOs)
                .WithRequired(e => e.tb_SO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.SONO)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.Queue)
                .HasPrecision(9, 2);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.StockCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.CustomerOrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SOs>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);
        }
    }
}

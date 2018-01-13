using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.CodeFirst.Models.Mapping;

namespace Metro.DynamicModeules.CodeFirst.Models
{
    public partial class CSFramework3NormalContext : DbContext
    {
        static CSFramework3NormalContext()
        {
            Database.SetInitializer<CSFramework3NormalContext>(null);
        }

        public CSFramework3NormalContext()
            : base("Name=CSFramework3NormalContext")
        {
        }

        public DbSet<dtproperty> dtproperties { get; set; }
        public DbSet<sys_BusinessTables> sys_BusinessTables { get; set; }
        public DbSet<sys_DataSN> sys_DataSN { get; set; }
        public DbSet<sys_DocSN> sys_DocSN { get; set; }
        public DbSet<sys_FieldNameDefs> sys_FieldNameDefs { get; set; }
        public DbSet<sys_Modules> sys_Modules { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tb_AccountIDs> tb_AccountIDs { get; set; }
        public DbSet<tb_AP> tb_AP { get; set; }
        public DbSet<tb_APs> tb_APs { get; set; }
        public DbSet<tb_AR> tb_AR { get; set; }
        public DbSet<tb_ARs> tb_ARs { get; set; }
        public DbSet<tb_AttachFile> tb_AttachFile { get; set; }
        public DbSet<tb_CommDataDictType> tb_CommDataDictType { get; set; }
        public DbSet<tb_CommonDataDict> tb_CommonDataDict { get; set; }
        public DbSet<tb_CompanyInfo> tb_CompanyInfo { get; set; }
        public DbSet<tb_Currency> tb_Currency { get; set; }
        public DbSet<tb_Customer> tb_Customer { get; set; }
        public DbSet<tb_CustomerAttribute> tb_CustomerAttribute { get; set; }
        public DbSet<tb_IA> tb_IA { get; set; }
        public DbSet<tb_IAs> tb_IAs { get; set; }
        public DbSet<tb_IC> tb_IC { get; set; }
        public DbSet<tb_ICs> tb_ICs { get; set; }
        public DbSet<tb_IN> tb_IN { get; set; }
        public DbSet<tb_INs> tb_INs { get; set; }
        public DbSet<tb_IO> tb_IO { get; set; }
        public DbSet<tb_IOs> tb_IOs { get; set; }
        public DbSet<tb_Location> tb_Location { get; set; }
        public DbSet<tb_Log> tb_Log { get; set; }
        public DbSet<tb_LogDtl> tb_LogDtl { get; set; }
        public DbSet<tb_LogFields> tb_LogFields { get; set; }
        public DbSet<tb_LoginLog> tb_LoginLog { get; set; }
        public DbSet<tb_MyAuthorityItem> tb_MyAuthorityItem { get; set; }
        public DbSet<tb_MyFormTagName> tb_MyFormTagName { get; set; }
        public DbSet<tb_MyMenu> tb_MyMenu { get; set; }
        public DbSet<tb_MyUser> tb_MyUser { get; set; }
        public DbSet<tb_MyUserGroup> tb_MyUserGroup { get; set; }
        public DbSet<tb_MyUserGroupRe> tb_MyUserGroupRe { get; set; }
        public DbSet<tb_MyUserRole> tb_MyUserRole { get; set; }
        public DbSet<tb_PayType> tb_PayType { get; set; }
        public DbSet<tb_Person> tb_Person { get; set; }
        public DbSet<tb_PO> tb_PO { get; set; }
        public DbSet<tb_POs> tb_POs { get; set; }
        public DbSet<tb_Product> tb_Product { get; set; }
        public DbSet<tb_ProductCategory> tb_ProductCategory { get; set; }
        public DbSet<tb_SO> tb_SO { get; set; }
        public DbSet<tb_SOs> tb_SOs { get; set; }
        public DbSet<vw_APs> vw_APs { get; set; }
        public DbSet<vw_ARs> vw_ARs { get; set; }
        public DbSet<vw_CommonDataDicts> vw_CommonDataDicts { get; set; }
        public DbSet<vw_IAs> vw_IAs { get; set; }
        public DbSet<vw_ICs> vw_ICs { get; set; }
        public DbSet<vw_INs> vw_INs { get; set; }
        public DbSet<vw_IOs> vw_IOs { get; set; }
        public DbSet<vw_LogOPType> vw_LogOPType { get; set; }
        public DbSet<vw_POs> vw_POs { get; set; }
        public DbSet<vw_SOs> vw_SOs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new dtpropertyMap());
            modelBuilder.Configurations.Add(new sys_BusinessTablesMap());
            modelBuilder.Configurations.Add(new sys_DataSNMap());
            modelBuilder.Configurations.Add(new sys_DocSNMap());
            modelBuilder.Configurations.Add(new sys_FieldNameDefsMap());
            modelBuilder.Configurations.Add(new sys_ModulesMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new tb_AccountIDsMap());
            modelBuilder.Configurations.Add(new tb_APMap());
            modelBuilder.Configurations.Add(new tb_APsMap());
            modelBuilder.Configurations.Add(new tb_ARMap());
            modelBuilder.Configurations.Add(new tb_ARsMap());
            modelBuilder.Configurations.Add(new tb_AttachFileMap());
            modelBuilder.Configurations.Add(new tb_CommDataDictTypeMap());
            modelBuilder.Configurations.Add(new tb_CommonDataDictMap());
            modelBuilder.Configurations.Add(new tb_CompanyInfoMap());
            modelBuilder.Configurations.Add(new tb_CurrencyMap());
            modelBuilder.Configurations.Add(new tb_CustomerMap());
            modelBuilder.Configurations.Add(new tb_CustomerAttributeMap());
            modelBuilder.Configurations.Add(new tb_IAMap());
            modelBuilder.Configurations.Add(new tb_IAsMap());
            modelBuilder.Configurations.Add(new tb_ICMap());
            modelBuilder.Configurations.Add(new tb_ICsMap());
            modelBuilder.Configurations.Add(new tb_INMap());
            modelBuilder.Configurations.Add(new tb_INsMap());
            modelBuilder.Configurations.Add(new tb_IOMap());
            modelBuilder.Configurations.Add(new tb_IOsMap());
            modelBuilder.Configurations.Add(new tb_LocationMap());
            modelBuilder.Configurations.Add(new tb_LogMap());
            modelBuilder.Configurations.Add(new tb_LogDtlMap());
            modelBuilder.Configurations.Add(new tb_LogFieldsMap());
            modelBuilder.Configurations.Add(new tb_LoginLogMap());
            modelBuilder.Configurations.Add(new tb_MyAuthorityItemMap());
            modelBuilder.Configurations.Add(new tb_MyFormTagNameMap());
            modelBuilder.Configurations.Add(new tb_MyMenuMap());
            modelBuilder.Configurations.Add(new tb_MyUserMap());
            modelBuilder.Configurations.Add(new tb_MyUserGroupMap());
            modelBuilder.Configurations.Add(new tb_MyUserGroupReMap());
            modelBuilder.Configurations.Add(new tb_MyUserRoleMap());
            modelBuilder.Configurations.Add(new tb_PayTypeMap());
            modelBuilder.Configurations.Add(new tb_PersonMap());
            modelBuilder.Configurations.Add(new tb_POMap());
            modelBuilder.Configurations.Add(new tb_POsMap());
            modelBuilder.Configurations.Add(new tb_ProductMap());
            modelBuilder.Configurations.Add(new tb_ProductCategoryMap());
            modelBuilder.Configurations.Add(new tb_SOMap());
            modelBuilder.Configurations.Add(new tb_SOsMap());
            modelBuilder.Configurations.Add(new vw_APsMap());
            modelBuilder.Configurations.Add(new vw_ARsMap());
            modelBuilder.Configurations.Add(new vw_CommonDataDictsMap());
            modelBuilder.Configurations.Add(new vw_IAsMap());
            modelBuilder.Configurations.Add(new vw_ICsMap());
            modelBuilder.Configurations.Add(new vw_INsMap());
            modelBuilder.Configurations.Add(new vw_IOsMap());
            modelBuilder.Configurations.Add(new vw_LogOPTypeMap());
            modelBuilder.Configurations.Add(new vw_POsMap());
            modelBuilder.Configurations.Add(new vw_SOsMap());
        }
    }
}

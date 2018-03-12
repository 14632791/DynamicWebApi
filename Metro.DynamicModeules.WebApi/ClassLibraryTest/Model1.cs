namespace ClassLibraryTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model15")
        {
        }

        public virtual DbSet<sys_Modules> sys_Modules { get; set; }
        public virtual DbSet<tb_MyAuthorityByItem> tb_MyAuthorityByItem { get; set; }
        public virtual DbSet<tb_MyAuthorityItem> tb_MyAuthorityItem { get; set; }
        public virtual DbSet<tb_MyMenu> tb_MyMenu { get; set; }
        public virtual DbSet<tb_MyUser> tb_MyUser { get; set; }
        public virtual DbSet<tb_MyUserGroup> tb_MyUserGroup { get; set; }
        public virtual DbSet<tb_MyUserGroupRe> tb_MyUserGroupRe { get; set; }
        public virtual DbSet<tb_MyUserGroupRole> tb_MyUserGroupRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_MyMenu>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyMenu>()
                .Property(e => e.MenuType)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.FlagAdmin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.FlagOnline)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.DataSets)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUser>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroup>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroup>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroup>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRe>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRe>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRole>()
                .Property(e => e.GroupCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRole>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tb_MyUserGroupRole>()
                .Property(e => e.LastUpdatedBy)
                .IsUnicode(false);
        }
    }
}

namespace Metro.DynamicModeules.CodeFirst.Demo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<sys_DataSN> sys_DataSN { get; set; }
        public virtual DbSet<sys_DocSN> sys_DocSN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}

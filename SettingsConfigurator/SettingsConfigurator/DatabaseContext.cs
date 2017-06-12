namespace SettingsConfigurator
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<UIDatabase> UIDatabases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.Server)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.Display)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.SQLUser)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.SQLPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.VersionUI)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.VersionBusiness)
                .IsUnicode(false);

            modelBuilder.Entity<UIDatabase>()
                .Property(e => e.Year)
                .IsUnicode(false);
        }
    }
}

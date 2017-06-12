namespace SettingsConfigurator
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SettingsContext : DbContext
    {
        public SettingsContext()
            : base("name=SettingsContext")
        {
        }

        public virtual DbSet<EncryptSubmitSetting> EncryptSubmitSettings { get; set; }
        public virtual DbSet<UI_vDeliveries> UI_vDeliveries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.Regime)
                .IsUnicode(false);

            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.TestOrProduction)
                .IsUnicode(false);

            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.B021)
                .IsUnicode(false);

            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.TransmittingCountry)
                .IsUnicode(false);

            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.dscmm)
                .IsUnicode(false);

            modelBuilder.Entity<UI_vDeliveries>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}

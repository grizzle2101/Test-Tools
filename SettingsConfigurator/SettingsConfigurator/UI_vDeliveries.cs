namespace SettingsConfigurator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UI_vDeliveries
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Regime { get; set; }

        [StringLength(10)]
        public string TestOrProduction { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string B021 { get; set; }

        [StringLength(50)]
        public string TransmittingCountry { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4000)]
        public string FilePath { get; set; }

        public string dscmm { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}

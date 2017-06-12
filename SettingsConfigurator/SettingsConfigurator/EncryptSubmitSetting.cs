namespace SettingsConfigurator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EncryptSubmitSetting
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string DatabaseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Transmitter { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(70)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Regime { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Production { get; set; }

        [StringLength(80)]
        public string ServerName { get; set; }

        [StringLength(10)]
        public string Port { get; set; }

        [StringLength(40)]
        public string Username { get; set; }

        public string Password { get; set; }

        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Certificate { get; set; }

        public string CertificatePassword { get; set; }

        [StringLength(250)]
        public string DataPacketSigningCert { get; set; }

        public string DataPacketSigningCertPassword { get; set; }

        [StringLength(80)]
        public string SFTPServer { get; set; }

        [StringLength(10)]
        public string SFTPPort { get; set; }

        [StringLength(40)]
        public string SFTPUsername { get; set; }

        public string SFTPPassword { get; set; }

        [StringLength(2048)]
        public string WebServiceUrl { get; set; }

        [StringLength(30)]
        public string MailServerType { get; set; }
    }
}

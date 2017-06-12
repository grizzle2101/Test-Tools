namespace SettingsConfigurator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UIDatabase")]
    public partial class UIDatabase
    {
        public long ID { get; set; }

        public long UIEntity_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Server { get; set; }

        [Required]
        [StringLength(500)]
        public string Display { get; set; }

        public bool SQLSecurity { get; set; }

        [StringLength(250)]
        public string SQLUser { get; set; }

        [StringLength(250)]
        public string SQLPassword { get; set; }

        public bool IsReadOnly { get; set; }

        public bool? Deleted { get; set; }

        [StringLength(250)]
        public string VersionUI { get; set; }

        [StringLength(250)]
        public string VersionBusiness { get; set; }

        [StringLength(4)]
        public string Year { get; set; }

        public bool IsFourEyesValidation { get; set; }

        public bool IsWorkflows { get; set; }
    }
}

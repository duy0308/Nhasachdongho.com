namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1RoleActions
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        public int WebActionId { get; set; }

        public virtual M1WebActions M1WebActions { get; set; }

        public virtual M1Roles M1Roles { get; set; }
    }
}

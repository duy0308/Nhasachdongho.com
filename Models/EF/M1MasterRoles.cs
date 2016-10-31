namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M1MasterRoles
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MasterId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        public virtual M1Roles M1Roles { get; set; }

        public virtual M1Masters M1Masters { get; set; }
    }
}

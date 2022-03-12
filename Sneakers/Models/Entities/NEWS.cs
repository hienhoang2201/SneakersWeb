namespace Sneakers.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NEWS
    {
        [Key]
        public int NewID { get; set; }

        [StringLength(100)]
        public string NewsTitle { get; set; }

        [StringLength(200)]
        public string ImageLink { get; set; }

        [Column(TypeName = "ntext")]
        public string NewsDescription { get; set; }

        public DateTime? DayTime { get; set; }

        public int? AdminID { get; set; }

        public virtual ADMIN ADMIN { get; set; }
    }
}

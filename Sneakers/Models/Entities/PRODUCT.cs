namespace Sneakers.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ITEMs = new HashSet<ITEM>();
        }

        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProName { get; set; }

        [StringLength(200)]
        public string ImageLink { get; set; }

        [Column(TypeName = "ntext")]
        public string ProDescription { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string ProStatus { get; set; }

        public int? CategoryID { get; set; }

        public int? AdminID { get; set; }

        public virtual ADMIN ADMIN { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}

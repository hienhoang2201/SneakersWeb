namespace Sneakers.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ITEMs = new HashSet<ITEM>();
        }

        public int OrderID { get; set; }

        public double? Amount { get; set; }

        public DateTime? Daytime { get; set; }

        [StringLength(100)]
        public string DeliveryAddress { get; set; }

        [Column(TypeName = "ntext")]
        public string OrderDescription { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEMs { get; set; }

        public virtual USER USER { get; set; }
    }
}

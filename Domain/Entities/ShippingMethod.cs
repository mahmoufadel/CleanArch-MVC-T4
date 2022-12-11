using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("shipping_method")]
    public partial class ShippingMethod
    {
        public ShippingMethod()
        {
            CustOrders = new HashSet<CustOrder>();
        }

        [Key]
        [Column("method_id")]
        public int MethodId { get; set; }
        [Column("method_name")]
        [StringLength(100)]
        [Unicode(false)]
        public string? MethodName { get; set; }
        [Column("cost", TypeName = "decimal(6, 2)")]
        public decimal? Cost { get; set; }

        [InverseProperty(nameof(CustOrder.ShippingMethod))]
        public virtual ICollection<CustOrder> CustOrders { get; set; }
    }
}

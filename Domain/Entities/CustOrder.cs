using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("cust_order")]
    public partial class CustOrder
    {
        public CustOrder()
        {
            OrderHistories = new HashSet<OrderHistory>();
            OrderLines = new HashSet<OrderLine>();
        }

        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("order_date", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [Column("shipping_method_id")]
        public int? ShippingMethodId { get; set; }
        [Column("dest_address_id")]
        public int? DestAddressId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustOrders")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey(nameof(DestAddressId))]
        [InverseProperty(nameof(Address.CustOrders))]
        public virtual Address? DestAddress { get; set; }
        [ForeignKey(nameof(ShippingMethodId))]
        [InverseProperty("CustOrders")]
        public virtual ShippingMethod? ShippingMethod { get; set; }
        [InverseProperty(nameof(OrderHistory.Order))]
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        [InverseProperty(nameof(OrderLine.Order))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}

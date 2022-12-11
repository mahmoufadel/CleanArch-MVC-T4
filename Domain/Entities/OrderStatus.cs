using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("order_status")]
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        [Key]
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("status_value")]
        [StringLength(20)]
        [Unicode(false)]
        public string? StatusValue { get; set; }

        [InverseProperty(nameof(OrderHistory.Status))]
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}

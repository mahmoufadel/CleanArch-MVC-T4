using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("order_history")]
    public partial class OrderHistory
    {
        [Key]
        [Column("history_id")]
        public int HistoryId { get; set; }
        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("status_id")]
        public int? StatusId { get; set; }
        [Column("status_date", TypeName = "datetime")]
        public DateTime? StatusDate { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(CustOrder.OrderHistories))]
        public virtual CustOrder? Order { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(OrderStatus.OrderHistories))]
        public virtual OrderStatus? Status { get; set; }
    }
}

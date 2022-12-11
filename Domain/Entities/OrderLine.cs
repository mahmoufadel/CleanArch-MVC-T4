using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("order_line")]
    public partial class OrderLine
    {
        [Key]
        [Column("line_id")]
        public int LineId { get; set; }
        [Column("order_id")]
        public int? OrderId { get; set; }
        [Column("book_id")]
        public int? BookId { get; set; }
        [Column("price", TypeName = "decimal(5, 2)")]
        public decimal? Price { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("OrderLines")]
        public virtual Book? Book { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(CustOrder.OrderLines))]
        public virtual CustOrder? Order { get; set; }
    }
}

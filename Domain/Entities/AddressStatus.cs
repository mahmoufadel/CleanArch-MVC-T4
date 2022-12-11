using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("address_status")]
    public partial class AddressStatus
    {
        [Key]
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("address_status")]
        [StringLength(30)]
        [Unicode(false)]
        public string? AddressStatus1 { get; set; }
    }
}

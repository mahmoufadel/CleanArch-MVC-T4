using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("customer_address")]
    public partial class CustomerAddress
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Key]
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("status_id")]
        public int? StatusId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("CustomerAddresses")]
        public virtual Address Address { get; set; } = null!;
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; } = null!;
    }
}

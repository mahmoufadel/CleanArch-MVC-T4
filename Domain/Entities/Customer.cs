using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("customer")]
    public partial class Customer
    {
        public Customer()
        {
            CustOrders = new HashSet<CustOrder>();
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("first_name")]
        [StringLength(200)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [Column("last_name")]
        [StringLength(200)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [Column("email")]
        [StringLength(350)]
        [Unicode(false)]
        public string? Email { get; set; }

        [InverseProperty(nameof(CustOrder.Customer))]
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        [InverseProperty(nameof(CustomerAddress.Customer))]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}

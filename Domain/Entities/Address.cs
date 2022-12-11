using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("address")]
    public partial class Address
    {
        public Address()
        {
            CustOrders = new HashSet<CustOrder>();
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        [Key]
        [Column("address_id")]
        public int AddressId { get; set; }
        [Column("street_number")]
        [StringLength(10)]
        [Unicode(false)]
        public string? StreetNumber { get; set; }
        [Column("street_name")]
        [StringLength(200)]
        [Unicode(false)]
        public string? StreetName { get; set; }
        [Column("city")]
        [StringLength(100)]
        [Unicode(false)]
        public string? City { get; set; }
        [Column("country_id")]
        public int? CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Addresses")]
        public virtual Country? Country { get; set; }
        [InverseProperty(nameof(CustOrder.DestAddress))]
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        [InverseProperty(nameof(CustomerAddress.Address))]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}

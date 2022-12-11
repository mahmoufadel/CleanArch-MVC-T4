using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("country_id")]
        public int CountryId { get; set; }
        [Column("country_name")]
        [StringLength(200)]
        [Unicode(false)]
        public string? CountryName { get; set; }

        [InverseProperty(nameof(Address.Country))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}

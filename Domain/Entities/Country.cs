using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("country", Schema = "lookup")]
    public partial class Country
    {
        public Country()
        {
            Expenses = new HashSet<Expense>();
        }

        [Key]
        [Column("id")]
        public byte Id { get; set; }
        [Column("arabic_name")]
        [StringLength(200)]
        [Unicode(false)]
        public string ArabicName { get; set; } = null!;
        [Column("english_name")]
        [StringLength(200)]
        [Unicode(false)]
        public string? EnglishName { get; set; }

        [InverseProperty(nameof(Expense.CountryLkp))]
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}

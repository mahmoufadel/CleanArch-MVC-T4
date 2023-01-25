using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("collection_type", Schema = "lookup")]
    public partial class CollectionType
    {
        public CollectionType()
        {
            Expenses = new HashSet<Expense>();
        }

        [Key]
        [Column("id")]
        public byte Id { get; set; }
        [Column("name")]
        [StringLength(200)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Expense.CollectiontypeLkp))]
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}

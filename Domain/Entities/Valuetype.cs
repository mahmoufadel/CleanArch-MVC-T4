using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("valuetype", Schema = "lookup")]
    public partial class Valuetype
    {
        public Valuetype()
        {
            ExpenseSubtypes = new HashSet<ExpenseSubtype>();
        }

        [Key]
        [Column("id")]
        public byte Id { get; set; }
        [Column("name")]
        [StringLength(200)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(ExpenseSubtype.ValuetypeLkp))]
        public virtual ICollection<ExpenseSubtype> ExpenseSubtypes { get; set; }
    }
}

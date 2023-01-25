using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("expense_type", Schema = "lookup")]
    public partial class ExpenseType
    {
        public ExpenseType()
        {
            ExpenseAssignees = new HashSet<ExpenseAssignee>();
        }

        [Key]
        [Column("id")]
        public byte Id { get; set; }
        [Column("name")]
        [StringLength(200)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(ExpenseAssignee.ExpensetypeLkp))]
        public virtual ICollection<ExpenseAssignee> ExpenseAssignees { get; set; }
    }
}

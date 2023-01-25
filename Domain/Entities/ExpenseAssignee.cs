using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("expense_assignees", Schema = "fininvestment")]
    [Index(nameof(ExpenseId), Name = "IX_expense_assignees_expense_id")]
    [Index(nameof(ExpensetypeLkpId), Name = "IX_expense_assignees_expensetype_lkp_id")]
    public partial class ExpenseAssignee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("expense_id")]
        public int ExpenseId { get; set; }
        [Column("expensetype_lkp_id")]
        public byte ExpensetypeLkpId { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("edit_date")]
        public DateTime EditDate { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("edited_by")]
        public int EditedBy { get; set; }

        [ForeignKey(nameof(ExpenseId))]
        [InverseProperty("ExpenseAssignees")]
        public virtual Expense Expense { get; set; } = null!;
        [ForeignKey(nameof(ExpensetypeLkpId))]
        [InverseProperty(nameof(ExpenseType.ExpenseAssignees))]
        public virtual ExpenseType ExpensetypeLkp { get; set; } = null!;
    }
}

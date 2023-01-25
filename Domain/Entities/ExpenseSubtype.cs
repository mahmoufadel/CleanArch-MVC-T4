using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("expense_subtypes", Schema = "fininvestment")]
    [Index(nameof(ExpenseId), Name = "IX_expense_subtypes_expense_id")]
    [Index(nameof(ValuetypeLkpId), Name = "IX_expense_subtypes_valuetype_lkp_id")]
    public partial class ExpenseSubtype
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("value", TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        [Column("valuetype_lkp_id")]
        public byte ValuetypeLkpId { get; set; }
        [Column("maximum_value", TypeName = "decimal(18, 2)")]
        public decimal MaximumValue { get; set; }
        [Column("minimum_value", TypeName = "decimal(18, 2)")]
        public decimal MinimumValue { get; set; }
        [Column("gl_account")]
        public int GlAccount { get; set; }
        [Column("expense_id")]
        public int ExpenseId { get; set; }
        [Column("name")]
        [StringLength(200)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("edit_date")]
        public DateTime EditDate { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("edited_by")]
        public int EditedBy { get; set; }

        [ForeignKey(nameof(ExpenseId))]
        [InverseProperty("ExpenseSubtypes")]
        public virtual Expense Expense { get; set; } = null!;
        [ForeignKey(nameof(ValuetypeLkpId))]
        [InverseProperty(nameof(Valuetype.ExpenseSubtypes))]
        public virtual Valuetype ValuetypeLkp { get; set; } = null!;
    }
}

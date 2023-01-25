using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("expense", Schema = "fininvestment")]
    [Index(nameof(CollectiontypeLkpId), Name = "IX_expense_collectiontype_lkp_id")]
    [Index(nameof(CountryLkpId), Name = "IX_expense_country_lkp_id")]
    public partial class Expense
    {
        public Expense()
        {
            ExpenseAssignees = new HashSet<ExpenseAssignee>();
            ExpenseSubtypes = new HashSet<ExpenseSubtype>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("collectiontype_lkp_id")]
        public byte CollectiontypeLkpId { get; set; }
        [Column("expensetype_lkp_id")]
        public byte ExpensetypeLkpId { get; set; }
        [Column("country_lkp_id")]
        public byte CountryLkpId { get; set; }
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

        [ForeignKey(nameof(CollectiontypeLkpId))]
        [InverseProperty(nameof(CollectionType.Expenses))]
        public virtual CollectionType CollectiontypeLkp { get; set; } = null!;
        [ForeignKey(nameof(CountryLkpId))]
        [InverseProperty(nameof(Country.Expenses))]
        public virtual Country CountryLkp { get; set; } = null!;
        [InverseProperty(nameof(ExpenseAssignee.Expense))]
        public virtual ICollection<ExpenseAssignee> ExpenseAssignees { get; set; }
        [InverseProperty(nameof(ExpenseSubtype.Expense))]
        public virtual ICollection<ExpenseSubtype> ExpenseSubtypes { get; set; }
    }
}

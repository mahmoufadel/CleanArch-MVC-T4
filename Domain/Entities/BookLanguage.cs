using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("book_language")]
    public partial class BookLanguage
    {
        public BookLanguage()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Column("language_code")]
        [StringLength(8)]
        [Unicode(false)]
        public string? LanguageCode { get; set; }
        [Column("language_name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? LanguageName { get; set; }

        [InverseProperty(nameof(Book.Language))]
        public virtual ICollection<Book> Books { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Column("author_name")]
        [StringLength(400)]
        [Unicode(false)]
        public string? AuthorName { get; set; }

        [ForeignKey("AuthorId")]
        [InverseProperty(nameof(Book.Authors))]
        public virtual ICollection<Book> Books { get; set; }
    }
}

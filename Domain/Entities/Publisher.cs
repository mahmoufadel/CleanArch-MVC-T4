using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("publisher")]
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("publisher_id")]
        public int PublisherId { get; set; }
        [Column("publisher_name")]
        [StringLength(400)]
        [Unicode(false)]
        public string? PublisherName { get; set; }

        [InverseProperty(nameof(Book.Publisher))]
        public virtual ICollection<Book> Books { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Table("book")]
    public partial class Book
    {
        public Book()
        {
            OrderLines = new HashSet<OrderLine>();
            Authors = new HashSet<Author>();
        }

        [Key]
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("title")]
        [StringLength(400)]
        [Unicode(false)]
        public string? Title { get; set; }
        [Column("isbn13")]
        [StringLength(13)]
        [Unicode(false)]
        public string? Isbn13 { get; set; }
        [Column("language_id")]
        public int? LanguageId { get; set; }
        [Column("num_pages")]
        public int? NumPages { get; set; }
        [Column("publication_date", TypeName = "date")]
        public DateTime? PublicationDate { get; set; }
        [Column("publisher_id")]
        public int? PublisherId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        [InverseProperty(nameof(BookLanguage.Books))]
        public virtual BookLanguage? Language { get; set; }
        [ForeignKey(nameof(PublisherId))]
        [InverseProperty("Books")]
        public virtual Publisher? Publisher { get; set; }
        [InverseProperty(nameof(OrderLine.Book))]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        [ForeignKey("BookId")]
        [InverseProperty(nameof(Author.Books))]
        public virtual ICollection<Author> Authors { get; set; }
    }
}

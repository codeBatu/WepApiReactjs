using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable


namespace BookStoreEntites.Book
{
    public partial class Books
    {
        [Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? PageCount { get; set; }
        public DateTime PublicDateTime { get; set; }
    }
}

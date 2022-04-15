using System;
namespace BookOperaions.UpdateBook
{
    public class UpdateBooksModel
    {
        public string Title { get; set; }
       public int GenreId { get; set; }
       public int PageCount { get; set; }
      public DateTime? PublishDateTime { get; set; }
    }
}

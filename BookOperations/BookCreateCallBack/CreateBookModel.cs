using System;
namespace BookOperaions.BookCreateCallBack
{
    public class CreateBookModel
    {
        public string Title { get; set; }
       public int GenreId { get; set; }
       public int PageCount { get; set; }
      public DateTime? PublishDateTime { get; set; }
    }
}

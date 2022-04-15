using BookOperaions.BookContext;
using System.Linq;
using AutoMapper;
using BookStoreEntites.Book;
using System;

namespace BookOperaions.BookCreateCallBack
{
    public class BooksCreate
    {
        private readonly IMapper _mapper;
        private readonly bookContext _bookContext;

        public BooksCreate(bookContext bookContext, IMapper mapper)
        {
            _bookContext = bookContext;
            _mapper = mapper;
        }

        public void CreateBook(CreateBookModel model)
        {
            var data = _bookContext.Booktables.SingleOrDefault(data => data.Title == model.Title);
            if(data is not null)
               throw new System.Exception("hata");
          //    data = new Books();
          //    data.Title= model.Title;
          //    data.PageCount=model.PageCount;
          //    data.PublicDateTime= (DateTime)model.PublishDateTime;
          //    data.GenreId = model.GenreId;
              data= _mapper.Map<Books>(model);
           
              _bookContext.Add(data);
              _bookContext.SaveChanges();
             
        }
    }
}

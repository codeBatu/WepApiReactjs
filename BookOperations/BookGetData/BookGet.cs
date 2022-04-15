using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookOperaions.BookContext;
using BookOperaions.BookCreateCallBack;
using BookOperaions.Util;
using BookStoreEntites.Book;

namespace BookOperaions.BookGetData
{
    //TODO  callback yapıp async yap


    public class BookGet
    {
        private readonly IMapper _mapper;
        private readonly bookContext _bookContext;
        private static List<BookViewModel> bookList = new();

        public BookGet(bookContext bookContext, IMapper mapper)
        {
            _bookContext = bookContext;
            _mapper = mapper;
        }

        public List<BookViewModel> GetData()
        {
            var data = _bookContext.Booktables;
            bookList = _mapper.Map<List<BookViewModel>>(data);
         

            return bookList;
        }

        public BookViewModel GetDataByID(int id)
        {
            var datas = _bookContext.Booktables.SingleOrDefault(z => z.Id == id);
            if (datas is not null)
                return _mapper.Map<BookViewModel>(datas);
            return new BookViewModel();
        }
    }
}

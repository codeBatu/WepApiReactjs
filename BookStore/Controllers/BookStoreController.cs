using System;
using System.Collections.Generic;
using System.Linq;

using BookOperaions.BookContext;
using BookOperaions.BookCreateCallBack;
using BookOperaions.BookGetData;
using BookOperaions.UpdateBook;
using BookStoreEntites.Book;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BookStoreController : ControllerBase
    {
      private readonly bookContext _bookcontext;
        private readonly UpdateBook _bookUpdte;
        private readonly BooksCreate _bookCreate;
        private readonly BookGet _bookGet;

        public BookStoreController(BooksCreate bookCreate, bookContext bookContext,BookGet bookGet, UpdateBook updateBook)
        {
            _bookcontext = bookContext;
            _bookCreate = bookCreate;
            _bookUpdte= updateBook;
            _bookGet=bookGet;
        }

        [HttpGet("GetDATA")]
        public List<BookViewModel> GetData()
        {
            return _bookGet.GetData();
        }

        [HttpGet("{id}")]
        public BookViewModel GetData(int id)
        {
            var data = _bookGet.GetDataByID(id);

            return data;
        }

        [HttpPost]
        public IActionResult DataAdd([FromBody] CreateBookModel booksum)
        {
            _bookCreate.CreateBook(booksum);
            return Ok();
        }

        [HttpPut]
        public IActionResult DatapUT([FromBody] UpdateBooksModel booksum, int id)
        {
           _bookUpdte.UpdateData(id,booksum);

            return Ok();
        }

        [HttpDelete]
        public IActionResult remove(int id)
        {
            var bookdata = _bookcontext.Booktables.SingleOrDefault((x => x.Id == id));
            if (bookdata is null)
                return BadRequest();
            else
            {
                _bookcontext.Booktables.Remove(bookdata);
                _bookcontext.SaveChanges();
            }

            return Ok();
        }
    }
}

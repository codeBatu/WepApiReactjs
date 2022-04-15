using System;
using BookOperaions.BookContext;
using System.Linq;
using AutoMapper;

namespace BookOperaions.UpdateBook
{
    public class UpdateBook
    {
        private readonly bookContext _bookContext;
  private readonly IMapper _mapper;
        public UpdateBook(bookContext bookContext, IMapper mapper)
        {
            _bookContext = bookContext;
            _mapper = mapper;
        }

        public void UpdateData(int Id, UpdateBooksModel model)
        {
           var result = _bookContext.Booktables.SingleOrDefault(x=>x.Id==Id);
           if(result is null)
              return  ;

           var data = _mapper.Map<UpdateBooksModel>(result);
         //   result.Title=model.Title != default ? model.Title: result.Title;
         //   result.GenreId=model.GenreId !=default ?model.GenreId : result.GenreId;
         //   result.PageCount=model.PageCount != default ? model.PageCount : result.PageCount;
         //   result.PublicDateTime= (DateTime)((DateTime)model.PublishDateTime != default ?model.PublishDateTime: result.PublicDateTime);
          
     
            _bookContext.SaveChanges();  
        
        }
    }
}

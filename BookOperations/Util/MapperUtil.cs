using AutoMapper;
using BookOperaions.BookCreateCallBack;
using BookOperaions.BookGetData;
using BookOperaions.UpdateBook;
using BookStoreEntites.Book;

namespace BookOperaions.Util
{

    public class MapperUtil: Profile{

       public MapperUtil()
       {
           CreateMap<CreateBookModel,Books>();
        CreateMap<Books,BookViewModel>().ForMember(desc=>desc.Genre,opt=>opt.MapFrom(datas=>((GenreEnums)datas.GenreId).ToString()));
        CreateMap<Books,UpdateBooksModel>().ForMember(desc=>desc.GenreId,opt=>opt.MapFrom(datas=>((GenreEnums)datas.GenreId).ToString()));
       }
    }
}
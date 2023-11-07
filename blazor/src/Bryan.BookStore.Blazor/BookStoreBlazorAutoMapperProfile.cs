using Bryan.BookStore.Books;
using AutoMapper;
using Bryan.BookStore.Authors;

namespace Bryan.BookStore.Blazor
{
    public class BookStoreBlazorAutoMapperProfile : Profile
    {
        public BookStoreBlazorAutoMapperProfile()
        {
            CreateMap<BookDto, CreateUpdateBookDto>();
            CreateMap<AuthorDto, UpdateAuthorDto>();
        }
    }
}

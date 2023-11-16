using Bryan.BookStore.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bryan.BookStore.Books;

public interface IBookAppService : 
    ICrudAppService<
        BookDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateBookDto>
{
}

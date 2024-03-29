﻿using Bryan.BookStore.Books;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Bryan.BookStore;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() <= 0)
        {
            await _bookRepository.InsertAsync(new Book("1984", BookType.Dystopia, new DateTime(1949, 6, 8), 19.84f), autoSave: true);
            await _bookRepository.InsertAsync(new Book("The Hitchhiker's Guide to the Galaxy", BookType.ScienceFiction, new DateTime(1995, 9, 27), 42.0f), autoSave: true);
        }
    }
}

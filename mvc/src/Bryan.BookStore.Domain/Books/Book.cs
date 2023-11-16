using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bryan.BookStore.Books;

public class Book : AuditedAggregateRoot<Guid>
{
    public virtual string Name { get; protected set; }
    public virtual BookType Type { get; protected set; }
    public virtual DateTime PublishDate { get; protected set; }
    public virtual float Price { get; protected set; }

    public Book(string name, BookType type, DateTime publishDate, float price)
    {
        Name = name;
        Type = type;
        PublishDate = publishDate;
        Price = price;
    }
}

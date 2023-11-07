using Bryan.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bryan.BookStore;

[DependsOn(
    typeof(BookStoreEntityFrameworkCoreTestModule)
    )]
public class BookStoreDomainTestModule : AbpModule
{

}

using System.Threading.Tasks;

namespace Bryan.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}

using System.Data.Entity;

namespace WebApi.OAuth.Jwt.Core
{
    public class Initializer : MigrateDatabaseToLatestVersion<BooksContext, Configuration>
    {
    }
}
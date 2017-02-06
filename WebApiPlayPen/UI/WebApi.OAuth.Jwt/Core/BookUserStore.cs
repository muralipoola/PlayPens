using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.OAuth.Jwt.Core
{
    public class BookUserStore : UserStore<IdentityUser>
    {
        public BookUserStore() : base(new BooksContext())
        {
        }
    }
}
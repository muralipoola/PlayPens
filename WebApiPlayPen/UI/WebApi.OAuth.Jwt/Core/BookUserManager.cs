using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.OAuth.Jwt.Core
{
    public class BookUserManager : UserManager<IdentityUser>
    {
        public BookUserManager() : base(new BookUserStore())
        {
        }
    }
}
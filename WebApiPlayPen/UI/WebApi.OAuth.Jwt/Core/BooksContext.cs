using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApi.OAuth.Jwt.Models;

namespace WebApi.OAuth.Jwt.Core
{
    public class BooksContext : IdentityDbContext
    {
        public BooksContext()
            : base("BooksContext")
        {
            
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
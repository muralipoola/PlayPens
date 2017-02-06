using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OAuth.Jwt.Core;

namespace WebApi.OAuth.Jwt.Controllers
{
    public class BooksController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new BooksContext())
            {
                return Ok(await context.Books.Include(x => x.Reviews).ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (var context = new BooksContext())
            {
                return Ok(await context.Books.Include(x => x.Reviews).FirstOrDefaultAsync(b => b.Id == id));
            }
        }
    }
}
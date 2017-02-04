using System.Collections.Generic;

namespace WebApiPlayPen.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}

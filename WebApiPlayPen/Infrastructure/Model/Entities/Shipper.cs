using System.Collections.Generic;

namespace WebApiPlayPen.Model
{
    public  class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

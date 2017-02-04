using System.Collections.Generic;

namespace WebApiPlayPen.Model
{
    public  class CustomerDemographic
    {
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}

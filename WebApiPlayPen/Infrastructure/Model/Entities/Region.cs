using System.Collections.Generic;

namespace WebApiPlayPen.Model
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
    
        public virtual ICollection<Territory> Territories { get; set; } = new HashSet<Territory>();
    }
}

namespace NHibernatePlayPen.Domain
{
   public class Benefit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Employee Employee { get; set; }
    }
}

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernatePlayPen.Domain;

namespace NHibernatePlayPen.Persistence.Mappings.ByCode
{
    public class AddressMapping : ClassMapping<Address>
    {
        public AddressMapping()
        {
            Id(a => a.Id, mapper => mapper.Generator(Generators.HighLow));

            Property(a => a.AddressLine1);
            Property(a => a.AddressLine2);
            Property(a => a.Postcode);
            Property(a => a.City);
            Property(a => a.Country);

            ManyToOne(a => a.Employee, mapper =>
            {
                mapper.Class(typeof(Employee));
                mapper.Column("Employee_Id");
                mapper.Unique(true);
            });
        }
    }
}

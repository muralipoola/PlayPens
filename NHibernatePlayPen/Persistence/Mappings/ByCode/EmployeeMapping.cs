using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernatePlayPen.Domain;

namespace NHibernatePlayPen.Persistence.Mappings.ByCode
{
    public class EmployeeMapping: ClassMapping<Employee>
    {
        public EmployeeMapping()
        {
            Id(e=>e.Id, mapper=>mapper.Generator(Generators.HighLow));

            Property(e=>e.EmployeeNumber);
            Property(e=>e.Firstname);
            Property(e=>e.Lastname);
            Property(e=>e.DateOfBirth);
            Property(e=>e.DateOfJoining);
            Property(e=>e.EmailAddress);
            Property(e=>e.IsAdmin);
            Property(e=>e.Password);

            Set(e => e.Benefits,
                mapper =>
                {
                    mapper.Key(k => k.Column("Employee_Id"));
                    mapper.Cascade(Cascade.All);
                },
                relation => relation.OneToMany(
                    mapping => mapping.Class(typeof (Benefit))));

            OneToOne(e=>e.ResidentialAddress, mapper =>
            {
                mapper.Cascade(Cascade.Persist);
                mapper.PropertyReference(a=>a.Employee);
            });
        }
    }
}

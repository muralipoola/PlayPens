using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernatePlayPen.Domain;

namespace NHibernatePlayPen.Persistence.Mappings.ByCode
{
    public class BenefitMapping : ClassMapping<Benefit>
    {
        public BenefitMapping()
        {
            Id(b => b.Id, mapper => mapper.Generator(Generators.HighLow));

            Property(b => b.Name);
            Property(b => b.Description);

            ManyToOne(b => b.Employee, mapping => mapping.Class(typeof (Employee)));
        }
    }

    public class LeaveMappings : SubclassMapping<Leave>
    {
        public LeaveMappings()
        {
            DiscriminatorValue("LVE");
            Property(l => l.Type);
            Property(l => l.AvailableEntitlement);
            Property(l => l.RemainingEntitlement);
        }
    }

    public class SeasonTicketLoanMappings :
        SubclassMapping<SeasonTicketLoan>
    {
        public SeasonTicketLoanMappings()
        {
            DiscriminatorValue("STL");
            Property(s => s.Amount);
            Property(s => s.MonthlyInstalment);
            Property(s => s.StartDate);
            Property(s => s.EndDate);
        }
    }

    public class SkillsEnhancementAllowanceMappings :
        SubclassMapping<SkillsEnhancementAllowance>
    {
        public SkillsEnhancementAllowanceMappings()
        {
            DiscriminatorValue("SEA");
            Property(s => s.Entitlement);
            Property(s => s.RemainingEntitlement);
        }
    }
}
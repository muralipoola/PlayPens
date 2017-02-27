using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NHibernatePlayPen.Persistence.Mappings.ByCode;
using NHibernatePlayPen.Tests.Mappings;
using Environment = NHibernate.Cfg.Environment;

namespace NHibernatePlayPen.Tests
{
    public class InMemoryDatabaseForXmlMappings : IDisposable
    {
        protected Configuration Config;
        protected ISessionFactory SessionFactory;
        public ISession Session { get; set; }

        public InMemoryDatabaseForXmlMappings()
        {
            Config = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof (SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof (SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "data source =:memory:");

                //.AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Employee.hbm.xml")
                //                .AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Benefit.hierarchy.hbm.xml");
                                //.AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Benefit.subclass.hbm.xml");
                               // .AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Benefit.concrete.hbm.xml");

            Config.AddMapping(GetMappings());
            SessionFactory = Config.BuildSessionFactory();
            Session = SessionFactory.OpenSession();

            new SchemaExport(Config).Execute(true, true, false,Session.Connection, Console.Out);
        }

        private HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();
            //mapper.AddMapping<EmployeeMapping>();
            //mapper.AddMapping<AddressMapping>();
            //mapper.AddMapping<BenefitMapping>();
            //mapper.AddMapping<LeaveMappings>();
            //mapper.AddMapping<SkillsEnhancementAllowanceMappings>();
            //mapper.AddMapping<SeasonTicketLoanMappings>();

            mapper.AddMappings(typeof(EmployeeMapping).Assembly.GetExportedTypes());
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        public void Dispose()
        {
            Session.Dispose();
            SessionFactory.Dispose();
        }
    }
}

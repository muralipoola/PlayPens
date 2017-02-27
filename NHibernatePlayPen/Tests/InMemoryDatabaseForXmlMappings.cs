using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
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
                .SetProperty(Environment.ConnectionString, "data source =:memory:")
                .AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Employee.hbm.xml")
                //.AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Benefit.hierarchy.hbm.xml");
                .AddFile(@"K:\GitHub\PlayPens\NHibernatePlayPen\Persistence\Mappings\Xml\Benefit.subclass.hbm.xml");

            SessionFactory = Config.BuildSessionFactory();
            Session = SessionFactory.OpenSession();

            new SchemaExport(Config).Execute(true, true, false,Session.Connection, Console.Out);
        }

        public void Dispose()
        {
            Session.Dispose();
            SessionFactory.Dispose();
        }
    }
}

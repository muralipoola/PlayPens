using NHibernate;
using NUnit.Framework;

namespace NHibernatePlayPen.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected InMemoryDatabaseForXmlMappings Database;
        protected ISession Session;

        [OneTimeSetUp]
        public void Setup()
        {
            Database = new InMemoryDatabaseForXmlMappings();
            Session = Database.Session;
        }
    }
}

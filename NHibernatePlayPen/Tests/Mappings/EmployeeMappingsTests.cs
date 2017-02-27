using System;
using NHibernate;
using NHibernatePlayPen.Domain;
using NUnit.Framework;

namespace NHibernatePlayPen.Tests.Mappings
{
    [TestFixture]
    public class EmployeeMappingsTests
    {
        private InMemoryDatabaseForXmlMappings _database;
        private ISession _session;

        [OneTimeSetUp]
        public void Setup()
        {
            _database = new InMemoryDatabaseForXmlMappings();
            _session = _database.Session;
        }

        [Test]
        public void MapsPrimitiveProperties()
        {
            object id;
            using (var transaction = _session.BeginTransaction())
            {
                id = _session.Save(new Employee
                {
                    EmployeeNumber = "5987123",
                    Firstname = "Hillary",
                    Lastname = "Gamble",
                    EmailAddress = "hillary.gamble@corporate.com",
                    DateOfBirth = new DateTime(1980, 4, 23),
                    DateOfJoining = new DateTime(2010, 7, 12),
                    IsAdmin = true,
                    Password = "password"
                });
                transaction.Commit();
            }
            _session.Clear();

            using (var transaction = _session.BeginTransaction())
            {
                var employee = _session.Get<Employee>(id);
                Assert.That(employee.EmployeeNumber, Is.EqualTo("5987123"));
                Assert.That(employee.Firstname, Is.EqualTo("Hillary"));
                Assert.That(employee.Lastname, Is.EqualTo("Gamble"));
                Assert.That(employee.EmailAddress,
                    Is.EqualTo("hillary.gamble@corporate.com"));
                Assert.That(employee.DateOfBirth.Year, Is.EqualTo(1980));
                Assert.That(employee.DateOfBirth.Month, Is.EqualTo(4));
                Assert.That(employee.DateOfBirth.Day, Is.EqualTo(23));
                Assert.That(employee.DateOfJoining.Year,
                    Is.EqualTo(2010));
                Assert.That(employee.DateOfJoining.Month, Is.EqualTo(7));
                Assert.That(employee.DateOfJoining.Day, Is.EqualTo(12));
                Assert.That(employee.IsAdmin, Is.True);
                Assert.That(employee.Password, Is.EqualTo("password"));
                transaction.Commit();
            }
        }
    }
}

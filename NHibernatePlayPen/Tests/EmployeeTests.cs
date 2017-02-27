using System.Collections.Generic;
using System.Linq;
using NHibernatePlayPen.Domain;
using NUnit.Framework;

namespace NHibernatePlayPen.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void EmployeeIsEntitledToPaidLeaves()
        {
            //Arrange
            var employee = new Employee();
            //Act
            employee.Benefits = new List<Benefit>();
            employee.Benefits.Add(new Leave
            {
                Type = LeaveType.Casual,
                AvailableEntitlement = 15
            });
            //Assert
            var paidLeave = employee.Benefits.OfType<Leave>().FirstOrDefault(l => l.Type
            == LeaveType.Casual);
            Assert.That(paidLeave, Is.Not.Null);
            Assert.That(paidLeave.AvailableEntitlement, Is.EqualTo(15));
        }
    }
}

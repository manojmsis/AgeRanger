using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgeRanger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AgeRanger.Services.Contracts;
using AgeRanger.Models;
using System.Data.Entity;

namespace AgeRanger.Services.Tests
{
    [TestClass()]
    public class PersonServiceTests
    {
        Mock<AgeRangerContext> mockContext = new Mock<AgeRangerContext>();
        PersonService _service;
        void setUP()
        {
            var dataPerson = new List<Person>
            {
                new Person { Id=1,Age=20,LastName="john",FirstName="mayor" },
                new Person { Id=2,Age=21,LastName="clive",FirstName="ben" },
                new Person {Id=3,Age=22,LastName="paul",FirstName="kers" },
            }.AsQueryable();

            var dataAgeGroup = new List<AgeGroup>
            {
                new AgeGroup { Id=1,MinAge=0,MaxAge=10,Description="0to10"},
                new AgeGroup { Id=2,MinAge=10,MaxAge=20,Description="10to20" },
                new AgeGroup {Id=3,MinAge=20,Description="20AndAbove" },
            }.AsQueryable();

            var mockSetPerson = new Mock<DbSet<Person>>();
            mockSetPerson.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(dataPerson.Provider);
            mockSetPerson.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(dataPerson.Expression);
            mockSetPerson.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(dataPerson.ElementType);
            mockSetPerson.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(() => dataPerson.GetEnumerator());

            var mockSetAgeGroup = new Mock<DbSet<AgeGroup>>();
            mockSetAgeGroup.As<IQueryable<AgeGroup>>().Setup(m => m.Provider).Returns(dataAgeGroup.Provider);
            mockSetAgeGroup.As<IQueryable<AgeGroup>>().Setup(m => m.Expression).Returns(dataAgeGroup.Expression);
            mockSetAgeGroup.As<IQueryable<AgeGroup>>().Setup(m => m.ElementType).Returns(dataAgeGroup.ElementType);
            mockSetAgeGroup.As<IQueryable<AgeGroup>>().Setup(m => m.GetEnumerator()).Returns(() => dataAgeGroup.GetEnumerator());

            mockContext = new Mock<AgeRangerContext>();
            mockContext.Setup(c => c.Persons).Returns(mockSetPerson.Object);
            mockContext.Setup(c => c.AgeGroups).Returns(mockSetAgeGroup.Object);

            _service = new PersonService(mockContext.Object);
        }

        [TestMethod()]
        public void PersonService_GetByID_Returns_1_Record_IfExists()
        {
            setUP();
             var person = _service.GetPerson(1);

            Assert.AreEqual("john", person.LName);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void PersonService_GetByID_Returns_Exception_If_ID_Not_Exists()
        {
            setUP();
            var person = _service.GetPerson(4);
        }
        [TestMethod()]
        public void PersonService_Expected_AgeGroupJohn_20AndAbove()
        {
            setUP();
            var personlist = _service.GetList("john");
            Assert.AreEqual("20AndAbove", personlist.First(x => x.LName == "john").AgeGroup);
        }


    }
}
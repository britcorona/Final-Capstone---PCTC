using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class PCTCRepositoryTests
    {
        [TestMethod]
        public void PCTCContextEnsureICanCreateInstance()
        {
            PCTCContext context = new PCTCContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanCreateInstance()
        {
            PCTCRepository repo = new PCTCRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetUsers()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { FirstName = "Joe" },
                new PCTCUser { FirstName = "Susie" }
            };
            Mock<PCTCContext> mock_context = new Mock<PCTCContext>();
            Mock<DbSet<PCTCUser>> mock_set = new Mock<DbSet<PCTCUser>>();

            mock_set.Object.AddRange(expected);

            var data_source = expected.AsQueryable();

            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            
            mock_context.Setup(a => a.PCTCUsers).Returns(mock_set.Object);
            PCTCRepository repo = new PCTCRepository(mock_context.Object);
            var actual = repo.GetAllUsers();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

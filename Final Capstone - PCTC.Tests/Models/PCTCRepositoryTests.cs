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
        private Mock<PCTCContext> mock_context;
        private Mock<DbSet<PCTCUser>> mock_set;
        private PCTCRepository repo;

        private void ConnectMocksToDataStore(IEnumerable<PCTCUser> data_store)
        {
            var data_source = data_store.AsQueryable<PCTCUser>();

            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.PCTCUsers).Returns(mock_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<PCTCContext>();
            mock_set = new Mock<DbSet<PCTCUser>>();
            repo = new PCTCRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            repo = null;
        }


        [TestMethod]
        public void PCTCContextEnsureICanCreateInstance()
        {
            PCTCContext context = mock_context.Object;
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanCreateInstance()
        {
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

            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            var actual = repo.GetAllUsers();
            Assert.AreEqual("Joe", actual.First().FirstName);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureIHaveAContext()
        {
            var actual = repo.Context;
            Assert.IsInstanceOfType(actual, typeof(PCTCContext));
        }
    }
}

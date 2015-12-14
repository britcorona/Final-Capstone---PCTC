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
        private Mock<DbSet<MovieData>> mock_moviedata_set;
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
                new PCTCUser { UserName = "Zach" },
                new PCTCUser { UserName = "Blake" }
            };

            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            var actual = repo.GetAllUsers();
            Assert.AreEqual("Zach", actual.First().UserName);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureIHaveAContext()
        {
            var actual = repo.Context;
            Assert.IsInstanceOfType(actual, typeof(PCTCContext));
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetUserByUserName()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "Arianna" },
                new PCTCUser { UserName = "bella" }
            };
            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);
            string username = "bella";
            PCTCUser actual_user = repo.GetUserByUserName(username);
            Assert.AreEqual("bella", actual_user.UserName);
        }

        [TestMethod]
        public void PCTCRepositoryGetUserByUserNameDoesNotExist()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "Arianna" },
                new PCTCUser { UserName = "bella" }
            };
            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);
            string username = "somethingbogus";
            PCTCUser actual_user = repo.GetUserByUserName(username);
            Assert.IsNull(actual_user);
        }

        [TestMethod]
        public void PCTCRepositoryGetUserByUserNameFailsMulitpleUsers()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "zach1" },
                new PCTCUser { UserName = "zach1" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "zach1";
            PCTCUser acutal_user = repo.GetUserByUserName(username);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureUserNameIsAvailable()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "zach2" },
                new PCTCUser { UserName = "blake9" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "bogus";
            bool is_available = repo.IsUserNameAvailable(username);
            Assert.IsTrue(is_available);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureUserNameIsNotAvailable()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "britt2" },
                new PCTCUser { UserName = "shoelover5" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "britt2";
            bool is_available = repo.IsUserNameAvailable(username);
            Assert.IsFalse(is_available);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureUserNameIsNotAvailableForMultipleUsers()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "adam1" },
                new PCTCUser { UserName = "adam1" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "adam1";
            bool is_available = repo.IsUserNameAvailable(username);
            Assert.IsFalse(is_available);
        }
    }
}

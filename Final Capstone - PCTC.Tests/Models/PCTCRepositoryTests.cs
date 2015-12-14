using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;
using System.Collections.Generic;
using Moq;

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
                new PCTCUser { FirstName = "Hardees" },
                new PCTCUser { FirstName = "Taco Bell" }
            };
            //Mock<JitterContext> mock_context = new Mock<JitterContext>();
            //Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();
            Mock<PCTCContext> mock_context = new Mock<PCTCContext>();
            Mock<DbSet<PCTCUser>> mock_set = new Mock<DbSet<PCTCUser>>();

            mock_set.Object.AddRange(expected);

            //mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);
            mock_context.Setup(a => a.PCTCUsers).Returns(mock_set.Object);
        }
    }
}

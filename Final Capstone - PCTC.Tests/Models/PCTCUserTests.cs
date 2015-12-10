using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class PCTCUserTests
    {
        [TestMethod]
        public void PCTCUserEnsureICanCreateAnInstance()
        {
            PCTCUser a_user = new PCTCUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void PCTCUserEnsureUserHasInformation()
        {
            PCTCUser a_user = new PCTCUser();

            a_user.FirstName = "Brittney";
            a_user.LastName = "Corona";

            Assert.AreEqual("Brittney", a_user.FirstName);
            Assert.AreEqual("Corona", a_user.LastName);
        }


    }
}

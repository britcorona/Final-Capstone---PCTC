using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;
using System.Collections.Generic;

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

            a_user.UserId = 1;
            a_user.FirstName = "Brittney";
            a_user.LastName = "Corona";
            a_user.UserName = "britcorona";

            Assert.AreEqual(1, a_user.UserId);
            Assert.AreEqual("Brittney", a_user.FirstName);
            Assert.AreEqual("Corona", a_user.LastName);
            Assert.AreEqual("britcorona", a_user.UserName);
        }

        [TestMethod]
        public void PCTCUserEnsureUserHasTC()
        {
            List<TimeCapsule> list_of_tc = new List<TimeCapsule>
            {
                new TimeCapsule { Name = "Something"},
                new TimeCapsule { Name = "Name" }
            };
            //JitterUser a_user = new JitterUser { Handle = "adam1", Jots = list_of_jots};
            PCTCUser a_user = new PCTCUser { FirstName = "Brittney", TCs = list_of_tc };

            List<TimeCapsule> actual_tcs = a_user.TCs;
            Assert.AreEqual(actual_tcs, list_of_tc);
        }
    }
}

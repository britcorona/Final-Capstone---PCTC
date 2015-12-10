using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class TimeCapsuleTests
    {
        [TestMethod]
        public void TCEnsureICanCreateAnInstance()
        {
            TimeCapsule a_tc = new TimeCapsule();
            Assert.IsNotNull(a_tc);
        }

        [TestMethod]
        public void TCEnsureCapsulesInformation()
        {
            TimeCapsule a_tc = new TimeCapsule();

            DateTime expected_time = DateTime.Now;
            a_tc.TimeCapsuleId = 1;
            a_tc.ContentInsideTCId = 1;
            a_tc.Name = "Name Here";
            a_tc.Date = expected_time;

            Assert.AreEqual(1, a_tc.TimeCapsuleId);
            Assert.AreEqual(1, a_tc.ContentInsideTCId);
            Assert.AreEqual("Name Here", a_tc.Name);
            Assert.AreEqual(expected_time, a_tc.Date);
        }
    }
}

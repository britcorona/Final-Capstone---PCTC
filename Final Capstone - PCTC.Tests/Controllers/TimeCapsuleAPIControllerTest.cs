using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Controllers;

namespace Final_Capstone___PCTC.Tests.Controllers
{
    [TestClass]
    public class TimeCapsuleAPIControllerTest
    {
        [TestMethod]
        public void TCAPIControllerEnsureICanCallGetAction()
        {
            TimeCapsuleAPIControllerTest my_controller = new TimeCapsuleAPIControllerTest();
            string expected_output = "Is this working?";
            string actual_output = my_controller.Get();
            Assert.AreEqual(expected_output, actual_output);
        }
    }
}

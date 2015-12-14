using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class ChildTests
    {
        [TestMethod]
        public void ChildEnsureChildHasInformation()
        {
            Child a_child = new Child();

            DateTime expected_time = DateTime.Now;
            a_child.ChildId = 1;
            a_child.UserId = 1;
            a_child.Date = expected_time;
            a_child.Name = "Name Here";
            a_child.Gender = "Boy";
            a_child.Image = "image.jpg";

            Assert.AreEqual(1, a_child.ChildId);
            Assert.AreEqual(1, a_child.UserId);
            Assert.AreEqual(expected_time, a_child.Date);
            Assert.AreEqual("Name Here", a_child.Name);
            Assert.AreEqual("Boy", a_child.Gender);
            Assert.AreEqual("image.jpg", a_child.Image);
        }
    }
}

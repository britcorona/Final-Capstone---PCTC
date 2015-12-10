using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class ContentInsideTCTests
    {
        [TestMethod]
        public void ContentEnsureICanCreateAnInstance()
        {
            ContentInsideTC content = new ContentInsideTC();
            Assert.IsNotNull(content);
        }

        [TestMethod]
        public void ContentEnsureItHasInformation()
        {
            ContentInsideTC content = new ContentInsideTC();
            
            //5 options to add: Movie Title, Song w/ Artist, Book Title, Note, Image Upload

            content.Type = "Something here";
            content.AgeWhenToView = 15;
            content.Description = "Maybe a short note here";

            Assert.AreEqual("Something here", content.Type);
            Assert.AreEqual(15, content.AgeWhenToView);
            Assert.AreEqual("Maybe a short note here", content.Description);
        }
    }
}

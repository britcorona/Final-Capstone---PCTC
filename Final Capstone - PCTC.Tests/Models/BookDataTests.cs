using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class BookDataTests
    {
        [TestMethod]
        public void BookDataEnsureICanCreateAnInstance()
        {
            BookData theBookData = new BookData();
            Assert.IsNotNull(theBookData);
        }

        [TestMethod]
        public void BookDataEnsureBookDataCanHasInformation()
        {
            BookData theBookData = new BookData();

            theBookData.BookId = 1;
            theBookData.Title = "Book Title";
            theBookData.Author = "Author Name";
            theBookData.BookCoverImg = "image.jpg";

            Assert.AreEqual(1, theBookData.BookId);
            Assert.AreEqual("Book Title", theBookData.Title);
            Assert.AreEqual("Author Name", theBookData.Author);
            Assert.AreEqual("image.jpg", theBookData.BookCoverImg);
        }
    }
}

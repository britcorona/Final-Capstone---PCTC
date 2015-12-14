using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class NoteDataTests
    {
        [TestMethod]
        public void NoteDataEnsureICanCreateAnInstance()
        {
            NoteData theNoteData = new NoteData();
            Assert.IsNotNull(theNoteData);
        }

        [TestMethod]
        public void NoteDataEnsureNoteDataHasInformation()
        {
            NoteData theNoteData = new NoteData();

            theNoteData.NoteId = 1;
            theNoteData.Title = "Note Title";
            theNoteData.Text = "Some note here";
            theNoteData.Link = "https://google.com";
            theNoteData.Image = "image.jpg";

            Assert.AreEqual(1, theNoteData.NoteId);
            Assert.AreEqual("Note Title", theNoteData.Title);
            Assert.AreEqual("Some note here", theNoteData.Text);
            Assert.AreEqual("https://google.com", theNoteData.Link);
            Assert.AreEqual("image.jpg", theNoteData.Image);
        }
    }
}

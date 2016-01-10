using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class SongDataTests
    {
        [TestMethod]
        public void SongDataEnsureICanCreateAnInstance()
        {
            SongData theSongData = new SongData();
            Assert.IsNotNull(theSongData);
        }

        [TestMethod]
        public void SongDataEnsureSongDataHasInformation()
        {
            SongData theSongData = new SongData();

            theSongData.SongId = 1;
            theSongData.Title = "Song Title Here";
            theSongData.Artist = "Artist Name";
            theSongData.Album = "Album Name";
            theSongData.CoverArt = "image.jpg"; //Find an api for album cover art

            Assert.AreEqual(1, theSongData.SongId);
            Assert.AreEqual("Song Title Here", theSongData.Title);
            Assert.AreEqual("Artist Name", theSongData.Artist);
            Assert.AreEqual("Album Name", theSongData.Album);
            Assert.AreEqual("image.jpg", theSongData.CoverArt);
        }
    }
}

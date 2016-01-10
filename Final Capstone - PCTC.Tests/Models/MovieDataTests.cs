using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class MovieDataTests
    {
        [TestMethod]
        public void MovieDataEnsureICanCreateAnInstance()
        {
            MovieData theMovieData = new MovieData();
            Assert.IsNotNull(theMovieData);
        }

        [TestMethod]
        public void MovieDataEnsureMovieHasInformation()
        {
            MovieData a_movie = new MovieData();

            a_movie.MovieId = 1;
            a_movie.TCId = 1;
            a_movie.Name = "Movie Name";
            a_movie.Poster = "image.jpg"; //api would put the image here...

            Assert.AreEqual(1, a_movie.MovieId);
            Assert.AreEqual(1, a_movie.TCId);
            Assert.AreEqual("Movie Name", a_movie.Name);
            Assert.AreEqual("image.jpg", a_movie.Poster);
        }
    }
}

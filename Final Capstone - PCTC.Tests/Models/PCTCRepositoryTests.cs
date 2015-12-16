using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Capstone___PCTC.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Final_Capstone___PCTC.Tests.Models
{
    [TestClass]
    public class PCTCRepositoryTests
    {
        private Mock<PCTCContext> mock_context;
        private Mock<DbSet<PCTCUser>> mock_set;
        private Mock<DbSet<TimeCapsule>> mock_timecapsule_set;
        private Mock<DbSet<BookData>> mock_booksdata_set;
        private Mock<DbSet<NoteData>> mock_notesdata_set;
        private Mock<DbSet<SongData>> mock_songsdata_set;
        private Mock<DbSet<MovieData>> mock_moviesdata_set;
        private PCTCRepository repo;

        private void ConnectMocksToDataStore(IEnumerable<PCTCUser> data_store)
        {
            var data_source = data_store.AsQueryable<PCTCUser>();

            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<PCTCUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.PCTCUsers).Returns(mock_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<TimeCapsule> data_store)
        {
            var data_source = data_store.AsQueryable<TimeCapsule>();

            mock_timecapsule_set.As<IQueryable<TimeCapsule>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_timecapsule_set.As<IQueryable<TimeCapsule>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_timecapsule_set.As<IQueryable<TimeCapsule>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_timecapsule_set.As<IQueryable<TimeCapsule>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.TimeCapsules).Returns(mock_timecapsule_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<BookData> data_store)
        {
            var data_source = data_store.AsQueryable<BookData>();

            mock_booksdata_set.As<IQueryable<BookData>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_booksdata_set.As<IQueryable<BookData>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_booksdata_set.As<IQueryable<BookData>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_booksdata_set.As<IQueryable<BookData>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.BooksData).Returns(mock_booksdata_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<NoteData> data_store)
        {
            var data_source = data_store.AsQueryable<NoteData>();

            mock_notesdata_set.As<IQueryable<NoteData>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_notesdata_set.As<IQueryable<NoteData>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_notesdata_set.As<IQueryable<NoteData>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_notesdata_set.As<IQueryable<NoteData>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.NotesData).Returns(mock_notesdata_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<SongData> data_store)
        {
            var data_source = data_store.AsQueryable<SongData>();

            mock_songsdata_set.As<IQueryable<SongData>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_songsdata_set.As<IQueryable<SongData>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_songsdata_set.As<IQueryable<SongData>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_songsdata_set.As<IQueryable<SongData>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.SongsData).Returns(mock_songsdata_set.Object);
        }

        private void ConnectMocksToDataStore(IEnumerable<MovieData> data_store)
        {
            var data_source = data_store.AsQueryable<MovieData>();

            mock_moviesdata_set.As<IQueryable<MovieData>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_moviesdata_set.As<IQueryable<MovieData>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_moviesdata_set.As<IQueryable<MovieData>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_moviesdata_set.As<IQueryable<MovieData>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.MoviesData).Returns(mock_moviesdata_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<PCTCContext>();
            mock_set = new Mock<DbSet<PCTCUser>>();
            mock_timecapsule_set = new Mock<DbSet<TimeCapsule>>();
            mock_booksdata_set = new Mock<DbSet<BookData>>();
            mock_moviesdata_set = new Mock<DbSet<MovieData>>();
            mock_notesdata_set = new Mock<DbSet<NoteData>>();
            mock_songsdata_set = new Mock<DbSet<SongData>>();
            repo = new PCTCRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            mock_timecapsule_set = null;
            mock_songsdata_set = null;
            mock_notesdata_set = null;
            mock_moviesdata_set = null;
            mock_booksdata_set = null;
            repo = null;
        }


        [TestMethod]
        public void PCTCContextEnsureICanCreateInstance()
        {
            PCTCContext context = mock_context.Object;
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanCreateInstance()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetUsers()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "Zach" },
                new PCTCUser { UserName = "Blake" }
            };

            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            var actual = repo.GetAllUsers();
            Assert.AreEqual("Zach", actual.First().UserName);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureIHaveAContext()
        {
            var actual = repo.Context;
            Assert.IsInstanceOfType(actual, typeof(PCTCContext));
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetUserByUserName()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "Arianna" },
                new PCTCUser { UserName = "bella" }
            };
            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);
            string username = "bella";
            PCTCUser actual_user = repo.GetUserByUserName(username);
            Assert.AreEqual("bella", actual_user.UserName);
        }

        [TestMethod]
        public void PCTCRepositoryGetUserByUserNameDoesNotExist()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "Arianna" },
                new PCTCUser { UserName = "bella" }
            };
            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);
            string username = "somethingbogus";
            PCTCUser actual_user = repo.GetUserByUserName(username);
            Assert.IsNull(actual_user);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void PCTCRepositoryGetUserByUserNameFailsMulitpleUsers()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "zach1" },
                new PCTCUser { UserName = "zach1" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "zach1";
            PCTCUser acutal_user = repo.GetUserByUserName(username);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureUserNameIsAvailable()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "zach2" },
                new PCTCUser { UserName = "blake9" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "bogus";
            bool is_available = repo.IsUserNameAvailable(username);
            Assert.IsTrue(is_available);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureUserNameIsNotAvailable()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "britt2" },
                new PCTCUser { UserName = "shoelover5" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "britt2";
            bool is_available = repo.IsUserNameAvailable(username);
            Assert.IsFalse(is_available);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureUserNameIsNotAvailableForMultipleUsers()
        {
            var expected = new List<PCTCUser>
            {
                new PCTCUser { UserName = "adam1" },
                new PCTCUser { UserName = "adam1" }
            };
            mock_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);
            string username = "adam1";
            bool is_available = repo.IsUserNameAvailable(username);
            Assert.IsFalse(is_available);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanCreateATimeCapsule()
        {
            List<TimeCapsule> expected_tcs = new List<TimeCapsule>();
            PCTCUser pctcuser_user1 = new PCTCUser { UserName = "brit2" };
            List<PCTCUser> expcted_users = new List<PCTCUser>();
            expcted_users.Add(pctcuser_user1);

            ConnectMocksToDataStore(expected_tcs);
            ConnectMocksToDataStore(expcted_users);
            
            string tcName = "TimeCapsule Name";
            mock_timecapsule_set.Setup(j => j.Add(It.IsAny<TimeCapsule>())).Callback((TimeCapsule s) => expected_tcs.Add(s));
            bool successful = repo.CreateTC(pctcuser_user1, tcName);
            Assert.IsTrue(successful);
            Assert.AreEqual(1, repo.GetAllTCs().Count);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetAllSongData()
        {
            List<SongData> expected_data = new List<SongData>
            {
                new SongData { Artist = "Artist Name", Album = "Album Name", Title = "Song Title" },
                new SongData { Artist = "Artist NameTwo", Album = "Album NameTwo", Title = "Song TitleTwo" },
                new SongData { Artist = "Artist NameThree", Album = "Album NameThree", Title = "Song TitleThree" }
            };
            mock_songsdata_set.Object.AddRange(expected_data);
            ConnectMocksToDataStore(expected_data);
            List<SongData> actual_data = repo.GetAllTheSongData();
            //expected_data.Sort();
            //actual_data.Sort();
            Assert.AreEqual(expected_data[0].Artist, actual_data[0].Artist);
            Assert.AreEqual(expected_data[1].Artist, actual_data[1].Artist);
            Assert.AreEqual(expected_data[2].Artist, actual_data[2].Artist);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetAllMovieData()
        {
            List<MovieData> expected_data = new List<MovieData>
            {
                new MovieData { Name = "Move Name" },
                new MovieData { Name = "Frozen" },
                new MovieData { Name = "Avengers" }
            };
            mock_moviesdata_set.Object.AddRange(expected_data);
            ConnectMocksToDataStore(expected_data);
            List<MovieData> actual_data = repo.GetAllTheMovieData();
            Assert.AreEqual(expected_data[0].Name, actual_data[0].Name);
            Assert.AreEqual(expected_data[1].Name, actual_data[1].Name);
            Assert.AreEqual(expected_data[2].Name, actual_data[2].Name);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetAllNoteData()
        {
            List<NoteData> expected_data = new List<NoteData>
            {
                new NoteData { Title = "Note One", Text = "Some text here." },
                new NoteData { Title = "Blah blah blah", Text = "more notes here or link" },
                new NoteData { Title = "Second Title of note", Text = "blah blah blah" }
            };
            mock_notesdata_set.Object.AddRange(expected_data);
            ConnectMocksToDataStore(expected_data);
            List<NoteData> actual_data = repo.GetAllTheNoteData();
            Assert.AreEqual(expected_data[0].Title, actual_data[0].Title);
            Assert.AreEqual(expected_data[1].Title, actual_data[1].Title);
            Assert.AreEqual(expected_data[2].Title, actual_data[2].Title);
        }

        [TestMethod]
        public void PCTCRepositoryEnsureICanGetAllBookData()
        {
            List<BookData> expected_data = new List<BookData>
            {
                new BookData { Title = "Book Title", Author = "Author Name" },
                new BookData { Title = "Title Here", Author = "Name Name" },
                new BookData { Title = "Another Title", Author = "Blah blah" }
            };
            mock_booksdata_set.Object.AddRange(expected_data);
            ConnectMocksToDataStore(expected_data);
            List<BookData> actual_data = repo.GetAllTheBookData();
            Assert.AreEqual(expected_data[0].Title, actual_data[0].Title);
            Assert.AreEqual(expected_data[1].Title, actual_data[1].Title);
            Assert.AreEqual(expected_data[2].Title, actual_data[2].Title);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class PCTCRepository
    {
        private PCTCContext _context;

        public PCTCContext Context { get { return _context; } }

        public PCTCRepository()
        {
            _context = new PCTCContext();
        }

        public PCTCRepository(PCTCContext a_context)
        {
            _context = a_context;
        }

        public List<PCTCUser> GetAllUsers()
        {
            var query = from users in _context.PCTCUsers select users;
            return query.ToList();
        }

        public PCTCUser GetUserByUserName(string username)
        {
            var query = from user in _context.PCTCUsers where user.UserName == username select user;
            // IQueryable<JitterUser> query = from user in _context.JitterUsers where user.Handle == handle select user;
            return query.SingleOrDefault();
        }

        public bool IsUserNameAvailable(string username)
        {
            bool available = false;
            try
            {
                PCTCUser some_user = GetUserByUserName(username);
                if (some_user == null)
                {
                    available = true;
                }
            }
            catch (InvalidOperationException)
            {
                //Nothing needs to be coded here.
            }
            return available;
        }

        public bool CreateTC(PCTCUser pctcuser_user1, string tcName)
        {
            TimeCapsule a_tc = new TimeCapsule { Name = tcName, Date = DateTime.Now, Owner = pctcuser_user1 };
            bool is_added = true;
            try
            {
                //pctcuser_user1.TCs.Add(a_tc);
                TimeCapsule added_tc = _context.TimeCapsules.Add(a_tc);
                _context.SaveChanges();
            } catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

        public List<TimeCapsule> GetAllTCs()
        {
            var query = from tc in _context.TimeCapsules select tc;
            List<TimeCapsule> found_tcs = query.ToList();
            found_tcs.Sort();
            return found_tcs;
        }

        public List<SongData> GetAllTheSongData()
        {
            var query = from sd in _context.SongsData select sd;
            List<SongData> found_data = query.ToList();
            //found_data.Sort();
            return found_data;
        }

        public List<MovieData> GetAllTheMovieData()
        {
            var query = from md in _context.MoviesData select md;
            List<MovieData> found_data = query.ToList();
            return found_data;
        }

        public List<NoteData> GetAllTheNoteData()
        {
            var query = from nd in _context.NotesData select nd;
            List<NoteData> found_data = query.ToList();
            return found_data;
        }

        public List<BookData> GetAllTheBookData()
        {
            var query = from bd in _context.BooksData select bd;
            List<BookData> foundd_data = query.ToList();
            return foundd_data;
        }
    }
}
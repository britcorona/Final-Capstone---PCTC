using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Final_Capstone___PCTC.Models
{
    public class PCTCContext : ApplicationDbContext
    {
        public virtual DbSet<PCTCUser> PCTCUsers { get; set; }
        //public DbSet<TimeCapsule> TCs { get; set; }

        //PCTCRepositoryTests Mock
        public virtual DbSet<TimeCapsule> TimeCapsules { get; set; }
        public virtual DbSet<BookData> BooksData { get; set; }
        public virtual DbSet<NoteData> NotesData { get; set; }
        public virtual DbSet<SongData> SongsData { get; set; }
        public virtual DbSet<MovieData> MoviesData { get; set; }

    }
}
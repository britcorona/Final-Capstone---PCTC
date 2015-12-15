using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class TimeCapsule
    {
        [Key]
        public int TCId { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string ChildImg { get; set; }

        //This connects with the user
        public PCTCUser Owner { get; set; }

        public List<SongData> ConnectionToSongData { get; set; }
        public List<NoteData> ConnectionToNoteData { get; set; }
        public List<MovieData> ConnectionToMovieData { get; set; }
        public List<BookData> ConnectionToBookData { get; set; }
    }
}
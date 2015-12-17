using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class TimeCapsule : IComparable
    {
        [Key]
        public int TCId { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string ChildImg { get; set; }

        [ForeignKey("PCTCUser")]
        public int? UserId { get; set; }

        //This connects with the user
        public virtual PCTCUser PCTCUser { get; set; } //renamed this from Owner

        public List<SongData> ConnectionToSongData { get; set; }
        public List<NoteData> ConnectionToNoteData { get; set; }
        public List<MovieData> ConnectionToMovieData { get; set; }
        public List<BookData> ConnectionToBookData { get; set; }

        public int CompareTo(object obj)
        {
            TimeCapsule other_tc = obj as TimeCapsule;
            return -1 * (this.Date.CompareTo(other_tc.Date));
        }
    }
}
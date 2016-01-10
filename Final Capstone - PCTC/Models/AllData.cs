using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class AllData
    {
        public List <BookData> BookData { get; set; }
        public List <SongData> SongData { get; set; }
        public List <NoteData> NoteData { get; set; }
        public List <MovieData> MovieData { get; set; }

        
    }
}
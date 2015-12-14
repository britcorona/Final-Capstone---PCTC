using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class NoteData
    {
        public string Image { get; set; }
        public string Link { get; set; }

        [Key]
        public int NoteId { get; set; }

        public string Text { get; set; }
        public string Title { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class NoteData
    {
        [Key]
        public int NoteId { get; set; }

        public string Image { get; set; }
        public string Link { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        //Connection to TimeCapsule.cs
        public TimeCapsule ConnectedNDToTC { get; set; }

        [ForeignKey("ConnectedNDToTC")]
        public int? TCId { get; set; }
    }
}

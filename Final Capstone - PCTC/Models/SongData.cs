using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class SongData
    {
        [Key]
        public int SongId { get; set; }

        public string Album { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }

        //Connection to TimeCapsule.cs
        public TimeCapsule ConnectedSDToTC { get; set; }

        [ForeignKey("ConnectedSDToTC")]
        public int? TCId { get; set; }

        public string CoverArt { get; set; }
    }
}
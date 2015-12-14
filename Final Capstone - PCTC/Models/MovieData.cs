using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class MovieData
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("TCId")]
        public int TCId { get; set; }

        public string Name { get; set; }
        public string Poster { get; set; }
    }
}
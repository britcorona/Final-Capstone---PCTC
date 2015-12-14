using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class BookData
    {
        public string Author { get; set; }

        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }
    }
}
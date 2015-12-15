using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class BookData
    {
        [Key]
        public int BookId { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }

        //Connection to TimeCapsule.cs
        public TimeCapsule ConnectedBDToTC { get; set; }
    }
}
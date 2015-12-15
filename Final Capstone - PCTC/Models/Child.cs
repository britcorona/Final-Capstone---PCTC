using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class Child
    {
        [Key]
        public int ChildId { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }

        //Connection of Child to User
        public PCTCUser ConnectionChildToUser { get; set; }
    }
}
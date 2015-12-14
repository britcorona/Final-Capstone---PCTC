﻿using System;
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

        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        

        //[ForeignKey("ChildId")]
        //public int ChildId { get; set; }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string ChildImg { get; set; }

        
    }
}
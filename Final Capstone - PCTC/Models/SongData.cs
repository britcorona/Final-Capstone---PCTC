﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class SongData
    {
        public string Album { get; set; }
        public string Artist { get; set; }

        [Key]
        public int SongId { get; set; }

        public string Title { get; set; }
    }
}
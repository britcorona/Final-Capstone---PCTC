using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class TimeCapsule
    {
        public int ContentInsideTCId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        [Key]
        public int TimeCapsuleId { get; set; }

    }
}
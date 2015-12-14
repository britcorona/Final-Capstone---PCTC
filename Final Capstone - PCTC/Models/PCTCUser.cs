using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Capstone___PCTC.Models
{
    public class PCTCUser
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public string UserName { get; set; }

        public List<TimeCapsule> TCs { get; set; }
        public List<Child> Child { get; set; }

        
        public int CompareTo(object obj)
        {
            PCTCUser other_user = obj as PCTCUser;
            int answer = this.UserName.CompareTo(other_user.UserName);
            return answer;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DFF.Models
{
    public class RegisterEventModel
    {
        [StringLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public int Time { get; set; }
        public int Date { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public bool? NeedAssist { get; set; }
        public string TyofIDFood { get; set; }
    }
}
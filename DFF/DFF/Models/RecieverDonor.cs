using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFF.Models
{
    public class RecieverDonor { 
    
        public Login loginInfor { get; set; }
        public bool IsDoner { get; set; }
        public bool IsReciever { get; set; }
        List<Donation> donations { get; set; }
    }
}
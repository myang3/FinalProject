﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFF.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public int DonorId { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string TyofIdFood { get; set; }
        //public string pictureUrl { get; set; }
    }
}
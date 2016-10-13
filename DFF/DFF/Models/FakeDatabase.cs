using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFF.Models
{
    public class FakeDatabase
    {
        public RecieverDoner GetDonor()
        {
            return new RecieverDoner() { IsDoner = true, loginInfor = new Login() { Name = "CMoney", Email = "cMone@r.com" } };
        }
        public RecieverDoner GetReciewver()
        {
            return new RecieverDoner() { IsDoner = false, loginInfor = new Login() { Name = "D More food to give", Email = "adsfsdafr.com" } } ;
        }

        public List<Donation> GetDonations()
        {
            return new List<Donation>() {

                new Donation() {  DateAndTime=DateTime.Now, Location="The pard", TyofIdFood="Veg"},
                new Donation() {  DateAndTime=DateTime.Now.AddDays(-2), Location="GC", TyofIdFood="Pizza"},
                new Donation() {  DateAndTime=DateTime.Now.AddDays(3).AddHours(8), Location="zoo", TyofIdFood="meat lovers"},
                new Donation() {  DateAndTime=DateTime.Now.AddHours(3), Location="Grand cricus", TyofIdFood="Veg"},
                new Donation() {  DateAndTime=DateTime.Now.AddHours(2), Location="BelleIslle", TyofIdFood="wennies"}            };
        }
    }
}

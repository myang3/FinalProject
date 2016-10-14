using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DFF.Controllers
{
    public class ListingController : Controller
    {
        List<Donor> donorList = new List<Donors>() {
                    new Donor(){ DonorID=1, DonorName="Steve", Donation = "50 pita wraps"},
                    new Donor(){ DonorID=2, DonorName="Bill", Donation= "5 cheese pizzas" },
                    new Donor(){ DonorID=3, DonorName="Ram", Donation= "salad and dessing" },
                    new Donor(){ DonorID=4, DonorName="Ron", Donation= "mixed sandwich trays" },
                    new Donor(){ DonorID=5, DonorName="Rob", Donation= "Pork chop, mashed potatoes,gravy for 27" }
                    };


        // GET: Listing
        public ViewResult Index()
        {
            ViewBag.Donor();
            return View();
        }
    }
}
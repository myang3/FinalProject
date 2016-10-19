using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFF.Models;
using System.Data.Entity;
using RestSharp;
using RestSharp.Authenticators;

namespace DFF.Controllers
{
    public class HomeController : Controller
    {
        DFFEntities1 dff = new DFFEntities1();
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our Overall Mission Statement";


            SendSimpleMessage("darius777hunter@gmail.com","dariushunter777@gmail.com","What up my homie");


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How You Can Reach Us";

            return View();
        }

        public static RestResponse SendSimpleMessage(string fromReceiverEmail, string toDonorEmail, string inputText)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "5e4f923c3a968c8e088848485828c182");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 "https://localhost:44317", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@YOUR_DOMAIN_NAME>");
            request.AddParameter("to", toDonorEmail);
            request.AddParameter("bcc", "dhunter18@hawkmail.hfcc.edu");
            request.AddParameter("subject", "Someone wants your Donation");
            request.AddParameter("text", inputText);
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

    }
}

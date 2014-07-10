using Reunion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reunion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Donate()
        {            
            return View();
        }       

        [HttpPost]
        public ActionResult Dinner(int numadults, int numkids)
        {
            PaypalWebService ws = new PaypalWebService();            
            var token = ws.GeneratePayPalToken(numadults, numkids);
            if (token.Status == Moolah.PaymentStatus.Successful)
            {
                Response.Redirect(token.RedirectUrl);
            }
            else
            {
                throw new Exception("Paypal has experienced issues, cannot process your request at this time.");
            }
            return View("Index");
        }
    }
}
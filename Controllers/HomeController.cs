using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuote.Models;
using CarInsuranceQuote.Controllers;

namespace CarInsuranceQuote.Controllers
{
    public class HomeController : Controller
    {
         
        public ActionResult Index()
        {
            using (CustomersEntities2 db = new CustomersEntities2())
            return View();
        }


    }
}

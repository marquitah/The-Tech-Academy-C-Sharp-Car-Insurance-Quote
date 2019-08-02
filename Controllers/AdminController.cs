using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuote;
using CarInsuranceQuote.Models;
using CarInsuranceQuote.Controllers;

namespace CarInsuranceQuote.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            using (CustomersEntities2 db = new CustomersEntities2())
            {
                
                List<CustomerInfo> total = (from c in db.CustomerInfoes where c.QuoteTotal != null select c).ToList();
                var totals = new List<CustomerInfo>();

                foreach (var totalQuote in total)
                {
                    var totaled = new CustomerInfo();
                    totaled.FirstName = totalQuote.FirstName;
                    totaled.LastName = totalQuote.LastName;
                    totaled.EmailAddress = totalQuote.EmailAddress;
                    totaled.QuoteTotal = totalQuote.QuoteTotal;
                    totals.Add(totaled);

                    db.CustomerInfoes.Add(totaled);
                    db.SaveChanges();
                }
                return View(totals);

            }



        }
    }
}
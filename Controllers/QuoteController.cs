using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsuranceQuote.Models;
using CarInsuranceQuote.Controllers;

namespace CarInsuranceQuote.Controllers
{
    public class QuoteController : Controller
    {
        public ActionResult Index()
        {
            
            using (CustomersEntities2 db = new CustomersEntities2())
            return View();
        }

        [HttpPost]

        //First method for signing up for free quote//
        public ActionResult initialSignUp(string FirstName, string LastName, string EmailAddress, string DateOfBirth,
                                    string CarYear, string CarMake, string CarModel, string DUI,
                                   string SpeedingTickets, string Coverage)
        {


            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(EmailAddress) || string.IsNullOrEmpty(DateOfBirth)
                || string.IsNullOrEmpty(CarYear) || string.IsNullOrEmpty(CarMake) || string.IsNullOrEmpty(CarModel) || string.IsNullOrEmpty(DUI) ||
                string.IsNullOrEmpty(SpeedingTickets) || string.IsNullOrEmpty(Coverage))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CustomersEntities2 db = new CustomersEntities2())


                {

                    var totaled = new CustomerInfo();

                    totaled.FirstName = FirstName;
                    totaled.LastName = LastName;
                    totaled.EmailAddress = EmailAddress;
                    totaled.DateOfBirth = DateOfBirth;
                    totaled.CarYear = (CarYear);
                    totaled.CarMake = CarMake;
                    totaled.CarModel = CarModel;
                    totaled.DUI = DUI;
                    totaled.SpeedingTickets = (SpeedingTickets);
                    totaled.Coverage = Coverage;
                    totaled.QuoteTotal = totalQuote(DateOfBirth, CarYear, CarMake, CarModel, DUI, SpeedingTickets, Coverage);

                    db.CustomerInfoes.Add(totaled);
                    db.SaveChanges();

                    




                }
                  
                return View("Index");
            }


        }

        //Second method to add up total quote
           public string totalQuote(string DateOfBirth, string CarYear, string CarMake, string CarModel,
                                     string DUI, string SpeedingTickets, string Coverage)
           {

            decimal totalPrice = 50;

                //Age Constraints

                var age = (DateTime.Now.Year - (Convert.ToDateTime(DateOfBirth)).Year);

                if (age < 25)
                {
                    totalPrice += 25;
                }

                if (age < 18)
                {
                    totalPrice += 100;
                }

                if (age > 100)
                {
                    totalPrice += 25;
                }

                //Car Constraints

                if (Convert.ToInt32(CarYear) < 2000)
                {
                    totalPrice += 25;
                }

                if (Convert.ToInt32(CarYear) > 2015)
                {
                    totalPrice += 25;
                }

                if (CarMake.ToLower() == "Porsche")
                {
                    totalPrice += 25;
                }

                if (CarModel.ToLower() == "911 Carrera")
                {
                    totalPrice += 25;
                }

                if (Convert.ToInt32(SpeedingTickets) > 0)
                {
                    totalPrice += 10;
                }

                if (Convert.ToInt32(DUI) > 0)
                {
                    totalPrice = (totalPrice / 4) + totalPrice;
                }

                if (DUI.ToLower() == "no")
                {
                    totalPrice *= 0;
                }

                if (Coverage.ToLower() == "full" || Coverage.ToLower() == "full coverage")
                {
                    totalPrice = (totalPrice / 2) + totalPrice;
                }

            ViewBag.TotalQuote = totalPrice;
                return Convert.ToString(totalPrice);

           }


       
    }
}   
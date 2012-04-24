using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDropdownList.Models;

namespace TestDropdownList.Controllers
{
    public class HomeController : Controller
    {
        public static IList<Person> _persons = new List<Person>()
        {
            new Person{ PersonId = 1, PersonName = "Michael", CityCode = "MNL" },
            new Person{ PersonId = 2, PersonName = "Linus", CityCode = "ALB" },            
            new Person{ PersonId = 3, PersonName = "John", CityCode = "SHA" }
        };

        public ViewResult Index()
        {                        
            return View(new Person());
        }

        public ViewResult Edit(int id)
        {

            Person personToEdit = (from p in _persons where p.PersonId == id select p).Single();
            personToEdit.CountryCode = (from c in Cities where c.CityCode == personToEdit.CityCode select c.CountryCode).Single();
            return View("Index", personToEdit);
        }

        [HttpPost]
        public JsonResult CountryList()
        {            
            // normally, you pass a list obtained from ORM or ADO.NET DataTable or DataReader
            return Json(Countries);
        }

        [HttpPost]
        public JsonResult CityList(string CountryCode)
        {
            // normally, you pass a list obtained from ORM or ADO.NET DataTable or DataReader
            return Json(from c in Cities 
                        where c.CountryCode == CountryCode 
                        select new { c.CityCode, c.CityName });
            
        }

        // MOCK DATA //


        public List<Country> Countries
        {
            get
            {
                return new List<Country>()
                {
                    new Country { CountryCode = "PH", CountryName = "Philippines" },
                    new Country { CountryCode = "CN", CountryName = "China" },
                    new Country { CountryCode = "CA", CountryName = "Canada" },
                    new Country { CountryCode = "JP", CountryName = "Japan" }
                };
            }
        }//Countries



        public List<City> Cities 
        {
            get 
            {
                return new List<City>()
                {
                    new City { CountryCode = "PH", CityCode = "MNL", CityName = "Manila" },
                    new City { CountryCode = "PH", CityCode = "MKT", CityName = "Makati" },
                    new City { CountryCode = "PH", CityCode = "CBU", CityName = "Cebu" },

                    new City { CountryCode = "CN", CityCode = "BEI", CityName = "Beijing" },
                    new City { CountryCode = "CN", CityCode = "SHA", CityName = "Shanghai" },

                    new City { CountryCode = "CA", CityCode = "TOR", CityName = "Toronto" },
                    new City { CountryCode = "CA", CityCode = "MAN", CityName = "Manitoba" },
                    new City { CountryCode = "CA", CityCode = "ALB", CityName = "Alberta" },
                    new City { CountryCode = "CA", CityCode = "VAN", CityName = "Vancouver" },

                    new City { CountryCode = "JP", CityCode = "TOK", CityName = "Tokyo" }
                    
                };
            }
        }//Cities      

    }//HomeController
}

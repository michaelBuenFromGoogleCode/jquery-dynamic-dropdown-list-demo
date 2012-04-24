using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestDropdownList.Models
{

    public class Person
    {
        
        public int PersonId { get; set; }
        
        public string PersonName { get; set; }
        
        [   Display(Name="Country"),
            Required
        ]   public string CountryCode { get; set; }
        
        [   Display(Name="City"),
            Required
        ]   public string CityCode { get; set; }

    }

    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }

    public class City
    {
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
    }


}
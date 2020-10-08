using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowAllServiceViewModel
    {
        public int ServiceId { get; set; }
        [Display(Name = "Data serwisu")]
        public DateTime DateService { get; set; }

        [Display(Name = "Marka")]
        public string Marke { get; set; }

        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Display(Name = "Numer rejestracyjny")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Rodzaj serwisu")]
        public string TypeService { get; set; }
    }
}
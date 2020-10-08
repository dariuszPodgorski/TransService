using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowAllVehicleViewModel
    {
        public int VehicleId { get; set; }
        [Display(Name = "Nr rejestracyjny")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Marka")]
        public string Marke { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Nr silnika")]
        public string EngineNumber { get; set; }
    }
}
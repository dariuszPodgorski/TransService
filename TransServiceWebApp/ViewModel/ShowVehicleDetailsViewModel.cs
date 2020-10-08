using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowVehicleDetailsViewModel
    {
        public int VehicleId { get; set; }

        [Display(Name = "Marka")]
        public string Marke { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Rok produkcji")]
        public string YearProduction { get; set; }

        [Display(Name = "Pojemność silnika")]
        public string EngineCompacity { get; set; }

        [Display(Name = "Rodzaj wyposażenia")]
        public string EquipmentVersion { get; set; }

        [Display(Name = "Rodzaj kabiny")]
        public string TypeBody { get; set; }

        [Display(Name = "Numer rejestracyjny")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Numer silnika")]
        public string EngineNumber { get; set; }

        [Display(Name = "Kolor")]
        public string Color { get; set; }


        
    }
}
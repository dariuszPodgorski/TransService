using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowDetailsServiceViewModel
    {
        public int ServiceId { get; set; }

        [Display(Name = "Marka")]
        public string Marke { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Rok produkcji")]
        public string YearProduction { get; set; }

        [Display(Name = "Pojemność silnika")]
        public string EngineCompacity { get; set; }

        [Display(Name = "Rodzaj kabiny")]
        public string TypeBody { get; set; }

        [Display(Name = "Numer rejestracyjny")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Numer silnika")]
        public string EngineNumber { get; set; }

        [Display(Name = "Kolor")]
        public string Color { get; set; }

        [Display(Name = "Data serwisu")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateService { get; set; }

        [Display(Name = "Uszkodzenia")]
        public string Defects { get; set; }

        [Display(Name = "Wymienione części")]
        public string ReplacedParts { get; set; }

        [Display(Name = "Szczegóły serwisu")]
        public string DescriptionRepair { get; set; }

        [Display(Name = "Przebieg")]
        public string TotalMileage { get; set; }

        [Display(Name = "Uwagi ")]
        public string Description { get; set; }
    }
}
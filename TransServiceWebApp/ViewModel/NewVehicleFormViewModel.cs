using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class NewVehicleFormViewModel
    {
        [Display(Name = "Marka")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Marke { get; set; }

        [Display(Name = "Model")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CarModel { get; set; }

        [Display(Name = "Rok produkcji")]
        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string YearProduction { get; set; }

        [Display(Name = "Pojemność silnika")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string EngineCompacity { get; set; }

        [Display(Name = "Wersja wyposażenia")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string EquipmentVersion { get; set; }

        [Display(Name = "Wersja nadwozia")]
        public string TypeBody { get; set; }

        [Display(Name = "Nr rejestracyjny")]
        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Numer silnika")]
        [Required]
        [StringLength(32, MinimumLength = 10)]
        public string EngineNumber { get; set; }

        [Display(Name = "Kolor")]
        public string Color { get; set; }


        [Display(Name = "Data OC")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateOC { get; set; }

        [Display(Name = "Numer OC")]
        [Required]
        public string NumberOC { get; set; }

        [Display(Name = "Numer przeglądu technicznego")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateTechnicalExamination { get; set; }


        [Display(Name = "Przebieg")]
        [Required]
        public string TotalMieage { get; set; }
    }
}
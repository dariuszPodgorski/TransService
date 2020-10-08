using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransServiceWebApp.ViewModel
{
    public class NewServiceFormForvarderViewModel
    {
        [Required]
        [Display(Name = "Pojazd")]
        public int VehicleId { get; set; }

        public SelectList VehicleList { get; set; }

        [Required]
        [Display(Name = "Data Serwisu")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateService { get; set; }

        [Required]
        [Display(Name = "Uszkodzenia")]
        [StringLength(32, MinimumLength = 3)]
        public string Defects { get; set; }

        [Required]
        [Display(Name = "Wymienione części")]
        [StringLength(128, MinimumLength = 3)]
        public string ReplacedParts { get; set; }

        [Required]
        [Display(Name = "Uwagi do przeprowadzonego serwisu")]
        [StringLength(258, MinimumLength = 3)]
        public string DescriptionRepair { get; set; }

        [Required]
        [Display(Name = "Przebieg")]
        [StringLength(32, MinimumLength = 3)]
        public string TotalMileage { get; set; }

        [Required]
        [Display(Name = "Uwagi")]
        [StringLength(128, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Typ serwisu")]
        public int TypeServiceId { get; set; }

        public SelectList TypeServiceList { get; set; }
    }
}
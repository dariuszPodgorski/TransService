using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransServiceWebApp.ViewModel
{
    public class AcceptOrderViewModel
    {
        public int OrderId { get; set; }
        [Display(Name = "Pojazd")]
        [Required]
        public int VehicleId { get; set; }
        public SelectList VehicleList { get; set; }

        [Display(Name = "Kierowca")]
        [Required]
        public int DriverId { get; set; }
        public SelectList DriverList { get; set; }
    }
}
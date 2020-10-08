using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowAllOrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Nr zamówienia")]
        public string NameOrder { get; set; }


        [Display(Name = "Miejscowość odbioru")]
        public string CityReception { get; set; }

        [Display(Name = "Data odbioru")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MaxDateReception { get; set; }

        [Display(Name = "Miejscowość dostarczenia")]
        public string CityDelivery { get; set; }
        [Display(Name = "Data dostarczenia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataMaxDelivery { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
}
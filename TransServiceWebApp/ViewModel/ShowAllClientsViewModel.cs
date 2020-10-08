using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowAllClientsViewModel
    {
        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; }

        [Display(Name = "NIP")]
        public string NIP { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Numer budynku")]
        public string NumberOfBuilding { get; set; }

        [Display(Name = "Numer lokalu")]
        public string NumberApartment { get; set; }
    }
}
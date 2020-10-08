using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowDetailsProfileClientViewModel
    {
        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }


        [Display(Name = "Numer mieszkania")]
        public string NumberApartment { get; set; }

        [Display(Name = "NIP")]
        public string NIP { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        public string Fax { get; set; }

        [Display(Name = "Imie")]
        public string FirstNameContact { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastNameContact { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneContact { get; set; }

        [Display(Name = "Adres e-mail")]
        public string EmailContact { get; set; }

    }
}
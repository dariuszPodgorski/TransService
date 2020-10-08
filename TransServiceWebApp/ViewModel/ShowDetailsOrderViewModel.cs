using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowDetailsOrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Display(Name = "Rodzaj ładunku")]
        public string TypeCargoName { get; set; }

        [Display(Name = "Nazwa firmy")]
        public string NameCompanyReception { get; set; }

        [Display(Name = "Kraj")]
        public string CountryReception { get; set; }

        [Display(Name = "Kod-pocztowy")]
        public string PostCodeReception { get; set; }

        [Display(Name = "Miasto")]
        public string CityReception { get; set; }


        [Display(Name = "Ulica")]
        public string StreetReception { get; set; }

        [Display(Name = "Numer budynku")]
        public string NumberOfBuildingReception { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneReception { get; set; }

        [Display(Name = "Adres e-mail")]
        public string EmailReception { get; set; }

        [Display(Name = "Data odbioru")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MaxDateReception { get; set; }

        [Display(Name = "Uwagi")]
        public string DescriptionReception { get; set; }

        [Display(Name = "Nazwa firmy")]
        public string NameCompanyDelivery { get; set; }

        [Display(Name = "Kraj")]
        public string CountryDelivery { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostCodeDelivery { get; set; }

        [Display(Name = "Miejscowość")]
        public string CityDelivery { get; set; }

        [Display(Name = "Ulica")]
        public string StreetDelivery { get; set; }

        [Display(Name = "Numer budynku")]
        public string NumberOfBuildingDelivery { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneDelivery { get; set; }

        [Display(Name = "Adres e-mail")]
        public string EmailDelivery { get; set; }

        [Display(Name = "Data dostarczenia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataMaxDelivery { get; set; }

        [Display(Name = "Uwagi")]
        public string DescriptionDelivery { get; set; }




        [Display(Name = "Ciężar")]
        public string LoadWidth { get; set; }

        [Display(Name = "Wysokość")]
        public string Height { get; set; }


        [Display(Name = "Szerokość")]
        public string Width { get; set; }

        [Display(Name = "Głębokość")]
        public string Depth { get; set; }
    }
}
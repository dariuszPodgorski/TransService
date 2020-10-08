using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransServiceWebApp.ViewModel
{
    public class NewOrderFormForvarderViewModel
    {
        [Display(Name = "Nazwa firmy")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string NameCompanyReception { get; set; }

        [Display(Name = "Kraj")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CountryReception { get; set; }

        [Display(Name = "Kod-pocztowy")]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string PostCodeReception { get; set; }

        [Display(Name = "Miasto")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CityReception { get; set; }


        [Display(Name = "Ulica")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string StreetReception { get; set; }

        [Display(Name = "Numer budynku")]
        [Required]
        [StringLength(7, MinimumLength = 1)]
        public string NumberOfBuildingReception { get; set; }

        [Display(Name = "Telefon")]
        [Required]
        [StringLength(9, MinimumLength = 5)]
        public string PhoneReception { get; set; }

        [Display(Name = "Adres e-mail")]
        [StringLength(32)]
        public string EmailReception { get; set; }

        [Display(Name = "Data odbioru")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime MaxDateReception { get; set; }

        [Display(Name = "Uwagi")]
        [StringLength(128)]
        public string DescriptionReception { get; set; }

        [Display(Name = "Nazwa firmy")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string NameCompanyDelivery { get; set; }

        [Display(Name = "Kraj")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CountryDelivery { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string PostCodeDelivery { get; set; }

        [Display(Name = "Miejscowość")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CityDelivery { get; set; }

        [Display(Name = "Ulica")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string StreetDelivery { get; set; }

        [Display(Name = "Numer budynku")]
        [Required]
        [StringLength(7, MinimumLength = 1)]
        public string NumberOfBuildingDelivery { get; set; }

        [Display(Name = "Telefon")]
        [Required]
        [StringLength(9, MinimumLength = 5)]
        public string PhoneDelivery { get; set; }

        [Display(Name = "Adres e-mail")]
        [StringLength(32)]
        public string EmailDelivery { get; set; }

        [Display(Name = "Data dostarczenia")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DataMaxDelivery { get; set; }

        [Display(Name = "Uwagi")]
        [StringLength(128)]
        public string DescriptionDelivery { get; set; }

        [Required]
        [Display(Name = "Typ ładunku")]
        public int TypeCargoId { get; set; }
        public SelectList TypeCargoList { get; set; }

        [Display(Name = "Klient")]
        [Required]
        public int ClientId { get; set; }
        public SelectList ClientList { get; set; }


        [Display(Name = "Ciężar")]
        [Required]
        [StringLength(32)]
        public string LoadWidth { get; set; }

        [Display(Name = "Wysokość")]
        [Required]
        [StringLength(32)]
        public string Height { get; set; }


        [Display(Name = "Szerokość")]
        [Required]
        [StringLength(32)]
        public string Width { get; set; }

        [Display(Name = "Głębokość")]
        [Required]
        [StringLength(32)]
        public string Depth { get; set; }

        [Display(Name = "Ilość")]
        [Required]
        public int Quantity { get; set; }
    }
}
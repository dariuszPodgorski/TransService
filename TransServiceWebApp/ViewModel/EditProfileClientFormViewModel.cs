using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class EditProfileClientFormViewModel
    {
        [Display(Name = "Nazwa firmy")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string CompanyName { get; set; }

        [Display(Name = "Kraj")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Country { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string PostCode { get; set; }

        [Display(Name = "Miasto")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Street { get; set; }

        [Display(Name = "Numer budynku")]
        [Required]
        [StringLength(7, MinimumLength = 1)]
        public string NumerOfBuilding { get; set; }

        [Display(Name = "Numer mieszkania")]
        [StringLength(4)]
        public string NumberApartment { get; set; }

        [Display(Name = "NIP")]
        [Required]
        [StringLength(14, MinimumLength = 10)]
        public string NIP { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required]
        [StringLength(9, MinimumLength = 7)]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(10)]
        public string Fax { get; set; }

        [Display(Name = "Imie")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string FirstNameContact { get; set; }

        [Display(Name = "Nazwisko")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string LastNameContact { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required]
        [StringLength(9, MinimumLength = 7)]
        public string PhoneContact { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string EmailContact { get; set; }

        public int IdClient { get; set; }

        public int IdLogin { get; set; }
    }
}
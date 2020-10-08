using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class PassCargoViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Data zdania")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateIssusing { get; set; }

        [Display(Name = "Osoba wydająca")]
        public string PersonAccepting { get; set; }
        [Display(Name = "Numer WZ")]
        public string NumberPZ { get; set; }

        [Display(Name = "Uwagi")]

        public string Descirption { get; set; }
    }
}
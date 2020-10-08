using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class AcceptCargoViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Data przyjęcia")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateAccepting { get; set; }

        [Display(Name = "Osoba wydająca")]
        public string PersonIssusing { get; set; }
        [Display(Name = "Numer WZ")]
        public string NumberWZ { get; set; }

        [Display(Name = "Uwagi")]

        public string Descirption { get; set; }
    }
}
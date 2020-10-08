using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TransServiceWebApp.Interface;

namespace TransServiceWebApp.ViewModel
{
    public class LoginViewModel : IPassword, ILogin
    {
        [Display(Name = "Login")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Hasło")]
        [Required]
        [StringLength(32, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
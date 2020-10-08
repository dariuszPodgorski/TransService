using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TransServiceWebApp.Interface;

namespace TransServiceWebApp.ViewModel
{
   
        public class ChangePasswordViewModel : IPassword, ILogin
        {
            public string Login { get; set; }

            [Display(Name = "Hasło")]
            [Required]
            [StringLength(32, MinimumLength = 3)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Nowe Hasło")]
            [Required]
            [DataType(DataType.Password)]
            [StringLength(32, MinimumLength = 3)]
            public string NewPassword { get; set; }

            [Display(Name = "Powtórz noew hasło ")]
            [Required]
            [DataType(DataType.Password)]
            [StringLength(32, MinimumLength = 3)]
            public string ReplayNewPassword { get; set; }
        }
    
}
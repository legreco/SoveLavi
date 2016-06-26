using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.View_Models
{
   public class Login
    {
        [Display(Name = "Identifiant")]
        [Required]
        public string username { get; set; }

        [Display(Name = "Mot de passe")]
        [Required]
        public string password { get; set; }
    }
}

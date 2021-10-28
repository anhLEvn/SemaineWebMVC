using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVCDemo.Models
{
    public class Abonne
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Obligatoire")]
        [Display(Name = "Nom")]
        public string  Nom { get; set; }

        [MinLength(5, ErrorMessage ="min 5 charactaire")]
        public string Email { get; set; }
    }
}
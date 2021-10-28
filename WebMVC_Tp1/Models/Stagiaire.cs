using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC_Tp1.Models
{
    public class Stagiaire
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Obigatoire")]
        [MinLength(2, ErrorMessage =" Min 2 charactaires") ]
        public string  Nom { get; set; }

        [Required(ErrorMessage = "Obigatoire")]
        [MinLength(2, ErrorMessage = " Min 2 charactaires")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Obigatoire")]

        [DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateNaissance { get; set;}

        public string Email { get; set; }
    }
}
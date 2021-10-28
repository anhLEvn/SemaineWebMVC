using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationASPAuth2.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string  Libelle { get; set; }
        public string  Photo { get; set; }

        public int  CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}
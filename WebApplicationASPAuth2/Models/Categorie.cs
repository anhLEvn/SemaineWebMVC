using System.Collections.Generic;

namespace WebApplicationASPAuth2.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Designation { get; set; }

        public virtual ICollection<Produit> Produites { get; set; }
    }
}
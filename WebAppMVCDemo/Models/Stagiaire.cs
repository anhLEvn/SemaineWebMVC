﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVCDemo.Models
{
    public class Stagiaire
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
    }
}
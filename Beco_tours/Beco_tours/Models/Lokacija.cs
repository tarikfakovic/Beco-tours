using System;
using System.Collections.Generic;

namespace Beco_tours.Models
{
    public class Lokacija
    {
        public int LokacijaID { get; set; }
        public string Grad { get; set; } = string.Empty;
        public string Naziv { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;

    }
}
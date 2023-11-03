using System;
using System.Collections.Generic;

namespace Beco_tours.Models
{
    public class Putnik
    {
        public int PutnikID { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public int Godine { get; set; }
    }
}
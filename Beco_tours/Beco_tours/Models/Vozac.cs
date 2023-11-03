using System;
using System.Collections.Generic;

namespace Beco_tours.Models
{
    public class Vozac
    {
        public int VozacID { get; set; }
        public string Ime { get; set; } = string.Empty;
        public int Godine { get; set; }
        public string Telefon { get; set; } = string.Empty;
        public string Kategorija { get; set; } = string.Empty;
        public DateTime ZaposljenAt { get; set; } = DateTime.Now;
    }
}

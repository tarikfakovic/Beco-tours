using System;
using System.ComponentModel.DataAnnotations;

namespace Beco_tours.Data.Dto.Vozac
{
	public class VozacReadOnlyDto
    {
        public int VozacID { get; set; }

        public string Ime { get; set; }
        
        public int Godine { get; set; }
        
        public string Telefon { get; set; }
        
        public string Kategorija { get; set; }

        public DateTime ZaposljenAt { get; set; }
    }
}


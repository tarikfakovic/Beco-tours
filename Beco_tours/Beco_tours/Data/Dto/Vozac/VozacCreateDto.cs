using System;
using System.ComponentModel.DataAnnotations;

namespace Beco_tours.Data.Dto.Vozac
{
	public class VozacCreateDto
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public int Godine { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Kategorija { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace Beco_tours.Data.Dto.Putnik
{
	public class PutnikUpdateDto
    {

        [Required]
        public int PutnikID { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public int Godine { get; set; }
    
    }
}


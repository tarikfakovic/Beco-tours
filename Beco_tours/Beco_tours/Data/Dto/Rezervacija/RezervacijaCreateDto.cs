using System;
using System.ComponentModel.DataAnnotations;

namespace Beco_tours.Data.Dto.Rezervacija
{
	public class RezervacijaCreateDto
    {
        [Required]
        public int PutnikID { get; set; }
        [Required]
        public decimal Cena { get; set; }
        [Required]
        public bool PovratnaKarta { get; set; }
        [Required]
        public int TuraID { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using Beco_tours.Data.Dto.Lokacija;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Data.Dto.Tura;

namespace Beco_tours.Data.Dto.Rezervacija
{
	public class RezervacijaUpdateDto
    {
        [Required]
        public int RezervacijaID { get; set; }
        [Required]
        public int PutnikID { get; set; }
        [Required]
        public decimal Cena { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public bool PovratnaKarta { get; set; }
        [Required]
        public int TuraID { get; set; }
    }
}


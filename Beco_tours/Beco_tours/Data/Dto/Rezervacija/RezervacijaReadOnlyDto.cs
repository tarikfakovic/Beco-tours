using System;
using Beco_tours.Data.Dto.Lokacija;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Data.Dto.Tura;

namespace Beco_tours.Data.Dto.Rezervacija
{
	public class RezervacijaReadOnlyDto
    {
        public int RezervacijaID { get; set; }
        public PutnikReadOnlyDto Putnik { get; set; }
        public int PutnikID { get; set; }
        public decimal Cena { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool PovratnaKarta { get; set; }
        public TuraReadOnlyDto Tura { get; set; }
        public int TuraID { get; set; }
    }
}


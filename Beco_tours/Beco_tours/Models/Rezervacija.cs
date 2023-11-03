using System;
namespace Beco_tours.Models
{
	public class Rezervacija
	{
		public int RezervacijaID { get; set; }
		public Putnik Putnik { get; set; }
		public int PutnikID { get; set; }
		public decimal Cena { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public bool PovratnaKarta { get; set; }
		public Tura Tura { get; set; }
		public int TuraID { get; set; }
	}
}


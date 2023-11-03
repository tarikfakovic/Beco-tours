using System;
namespace Beco_tours.Data.Dto.Putnik
{
	public class PutnikReadOnlyDto
	{
        public int PutnikID { get; set; }
        public string Ime { get; set; } 
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public int Godine { get; set; }
    }
}


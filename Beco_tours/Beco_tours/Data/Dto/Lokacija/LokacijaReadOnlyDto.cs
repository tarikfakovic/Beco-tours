using System;

namespace Beco_tours.Data.Dto.Lokacija
{
    public class LokacijaReadOnlyDto
    {
        public int LokacijaID { get; set; }

        public string Grad { get; set; }
        
        public string Naziv { get; set; }
        
        public string Adresa { get; set; }
    }
}


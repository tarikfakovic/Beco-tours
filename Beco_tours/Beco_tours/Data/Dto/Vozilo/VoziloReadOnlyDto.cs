using System;
using Beco_tours.Data.Dto.Tura;
using Beco_tours.Data.Dto.Vozac;

namespace Beco_tours.Data.Dto.Vozilo
{
	public class VoziloReadOnlyDto
    {
        public int VoziloID { get; set; }
        public string Brend { get; set; } = string.Empty;
        public string Tip { get; set; } = string.Empty;
        public string Boja { get; set; } = string.Empty;
        public int BrojSedista { get; set; }

    }
}


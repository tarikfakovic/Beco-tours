using System;
using System.Collections.Generic;

namespace Beco_tours.Models
{
    public class Vozilo
    {
        public int VoziloID { get; set; }
        public string Brend { get; set; } = string.Empty;
        public string Tip { get; set; } = string.Empty;
        public string Boja { get; set; } = string.Empty;
        public int BrojSedista { get; set; }

    }
}


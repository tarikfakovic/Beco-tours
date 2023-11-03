using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Beco_tours.Models
{
    public class Tura
    {
        public int TuraID { get; set; }
        public DateTime VremePolaska { get; set; }
        public DateTime VremeUkrcavanja { get; set; }
        public DateTime VremeStizanja { get; set; }

        public Vozilo Vozilo { get; set; }
        public int VoziloID { get; set; }

        public Vozac Vozac { get; set; }
        public int VozacID { get; set; }

        public Lokacija PolaznaLokacija { get; set; }
        public int PolaznaLokacijaID { get; set; }

        public Lokacija ZavrsnaLokacija { get; set; }
        public int ZavrsnaLokacijaID { get; set; }

        public TuraStatus Status { get; set; }

    }

    public enum TuraStatus
    {
        [EnumMember(Value ="Cekanje")]
        Cekanje,
        [EnumMember(Value = "Otkazana")]
        Otkazana,
        [EnumMember(Value = "Zavrsena")]
        Zavrsena
    }
}
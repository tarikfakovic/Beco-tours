using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Beco_tours.Data.Dto.Lokacija;
using Beco_tours.Data.Dto.Rezervacija;
using Beco_tours.Data.Dto.Vozac;
using Beco_tours.Data.Dto.Vozilo;
using Beco_tours.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Beco_tours.Data.Dto.Tura
{
    public class TuraReadOnlyDto
    {
        public int TuraID { get; set; }
        public DateTime VremePolaska { get; set; }
        public DateTime VremeUkrcavanja { get; set; }
        public DateTime VremeStizanja { get; set; }

        public VoziloReadOnlyDto Vozilo { get; set; }
        public int VoziloID { get; set; }

        public VozacReadOnlyDto Vozac { get; set; }
        public int VozacID { get; set; }

        public LokacijaReadOnlyDto PolaznaLokacija { get; set; }
        public int PolaznaLokacijaID { get; set; }

        public LokacijaReadOnlyDto ZavrsnaLokacija{ get; set; }
        public int ZavrsnaLokacijaID { get; set; }
/*        [JsonConverter(typeof(JsonStringEnumConverter))]*/
        public TuraStatus Status { get; set; }

    }
}



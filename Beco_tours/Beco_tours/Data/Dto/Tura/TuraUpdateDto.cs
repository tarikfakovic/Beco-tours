using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Beco_tours.Data.Dto.Vozilo;
using Beco_tours.Models;

namespace Beco_tours.Data.Dto.Tura
{
	public class TuraUpdateDto
    {
        [Required]
        public int TuraID { get; set; }
        [Required]
        public DateTime VremePolaska { get; set; }
        [Required]
        public DateTime VremeUkrcavanja { get; set; }
        [Required]
        public DateTime VremeStizanja { get; set; }

        [Required]
        public int VoziloID { get; set; }

        [Required]
        public int VozacID { get; set; }

        [Required]
        public int PolaznaLokacijaID { get; set; }

        [Required]
        public int ZavrsnaLokacijaID { get; set; }

        [Required]
/*        [JsonConverter(typeof(JsonStringEnumConverter))]*/
        public TuraStatus Status { get; set; }
    }
}


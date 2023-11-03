using System;
using System.ComponentModel.DataAnnotations;
using Beco_tours.Data.Dto.Vozac;

namespace Beco_tours.Data.Dto.Vozilo
{
	public class VoziloCreateDto
	{
        [Required]
        public string Brend { get; set; }
        [Required]
        public string Tip { get; set; }
        [Required]
        public string Boja { get; set; }
        [Required]
        public int BrojSedista { get; set; }

    }
}


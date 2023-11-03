using System;
using System.ComponentModel.DataAnnotations;

namespace Beco_tours.Data.Dto.Vozilo
{
	public class VoziloUpdateDto
    {
        [Required]
        public int VoziloID { get; set; }
        [Required]
        public string Brend { get; set; } = string.Empty;
        [Required]
        public string Tip { get; set; } = string.Empty;
        [Required]
        public string Boja { get; set; } = string.Empty;
        [Required]
        public int BrojSedista { get; set; }

    }
}


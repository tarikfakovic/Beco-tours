using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Data.Dto.Lokacija
{
	public class LokacijaUpdateDto
    {
        [Required]
        public int LokacijaID { get; set; }
        [Required]
        public string Grad { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
    }
}


using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Beco_tours.Data.Dto.Lokacija
{
    public class LokacijaCreateDto
    {
        [Required]
        public string Grad { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Data.Dto.Putnik
{
	public class PutnikCreateDto
	{
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public int Godine { get; set; }
    }
}


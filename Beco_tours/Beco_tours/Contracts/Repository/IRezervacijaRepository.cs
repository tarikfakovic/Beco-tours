using System;
using Beco_tours.Models;

namespace Beco_tours.Contracts.Repository
{
    public interface IRezervacijaRepository : IBaseRepository<Rezervacija>
    {
        Task<IEnumerable<Rezervacija>> GetAllRezervacije();
        Task<Rezervacija> GetRezervacijaByID(int id);
        Task<IEnumerable<Rezervacija>> GetRezervacijaByTuraID(int id);
        void CreateRezervacija(Rezervacija rezervacija);
        void UpdateRezervacija(Rezervacija rezervacija);
        void DeleteRezervacija(Rezervacija rezervacija);
    }
}
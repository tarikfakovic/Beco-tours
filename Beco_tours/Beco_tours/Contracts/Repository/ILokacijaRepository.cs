using System;
using Beco_tours.Models;

namespace Beco_tours.Contracts.Repository
{
    public interface ILokacijaRepository : IBaseRepository<Lokacija>
    {
        Task<IEnumerable<Lokacija>> GetAllLokacije();
        Task<Lokacija> GetLokacijaByID(int id);
        void CreateLokacija(Lokacija lokacija);
        void UpdateLokacija(Lokacija lokacija);
        void DeleteLokacija(Lokacija lokacija);
    }
}
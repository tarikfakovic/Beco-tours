using System;
using Beco_tours.Models;

namespace Beco_tours.Contracts.Repository
{
    public interface IVoziloRepository : IBaseRepository<Vozilo>
    {
        Task<IEnumerable<Vozilo>> GetAllVozila();
        Task<Vozilo> GetVoziloByID(int id);
        void CreateVozilo(Vozilo vozilo);
        void UpdateVozilo(Vozilo vozilo);
        void DeleteVozilo(Vozilo vozilo);
    }
}


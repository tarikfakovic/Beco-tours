using System;
using Beco_tours.Models;

namespace Beco_tours.Contracts.Repository
{
    public interface IVozacRepository : IBaseRepository<Vozac>
    {
        Task<IEnumerable<Vozac>> GetAllVozace();
        Task<Vozac> GetVozacByID(int id);
        void CreateVozac(Vozac vozac);
        void UpdateVozac(Vozac vozac);
        void DeleteVozac(Vozac vozac);
    }
}

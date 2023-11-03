using System;
using Beco_tours.Models;

namespace Beco_tours.Contracts.Repository
{
    public interface IPutnikRepository : IBaseRepository<Putnik>
    {
        Task<IEnumerable<Putnik>> GetAllPutnike();
        Task<Putnik> GetPutnikByID(int id);
        void CreatePutnik(Putnik putnik);
        void UpdatePutnik(Putnik putnik);
        void DeletePutnik(Putnik putnik);
    }
}


using System;
using Beco_tours.Models;

namespace Beco_tours.Contracts.Repository
{
    public interface ITuraRepository : IBaseRepository<Tura>
    {
        Task<IEnumerable<Tura>> GetAllTure();
        Task<Tura> GetTuraByID(int id);
        void CreateTura(Tura tura);
        void UpdateTura(Tura tura);
        void DeleteTura(Tura tura);
    }
}

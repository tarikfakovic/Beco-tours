using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Data.Dto.Rezervacija;
using Beco_tours.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Beco_tours.Repositories
{
    public class TuraRepository : BaseRepository<Tura>, ITuraRepository
    {
        public TuraRepository(ApplicationDbContext context) : base(context) { }

        public void CreateTura(Tura tura) => Create(tura);

        public void UpdateTura(Tura tura) => Update(tura);

        public void DeleteTura(Tura tura) => Delete(tura);

  /*       => await SelectAll().ToListAsync();*/
        public async Task<IEnumerable<Tura>> GetAllTure()
        {
            return await SelectAll()
                .Include(t => t.Vozac)
                .Include(t => t.Vozilo)
                .Include(t => t.PolaznaLokacija)
                .Include(t => t.ZavrsnaLokacija)
                .ToListAsync();
   
        }
        public async Task<Tura> GetTuraByID(int id)
        {
            return await SelectByCondition(tura => tura.TuraID == id)
                .Include(t => t.Vozac)
                .Include(t => t.Vozilo)
                .Include(t => t.PolaznaLokacija)
                .Include(t => t.ZavrsnaLokacija)
                .FirstOrDefaultAsync();
        }

    /*public async Task<Tura> GetTuraByID(int id) => await SelectByCondition(tura => tura.TuraID == id).FirstOrDefaultAsync();*/
}

}


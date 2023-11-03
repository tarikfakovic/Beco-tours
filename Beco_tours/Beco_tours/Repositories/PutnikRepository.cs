using System;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Models;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Repositories
{
    public class PutnikRepository : BaseRepository<Putnik>, IPutnikRepository
    {
        public PutnikRepository(ApplicationDbContext context) : base(context) { }

        public void CreatePutnik(Putnik putnik) => Create(putnik);

        public void UpdatePutnik(Putnik putnik) => Update(putnik);

        public void DeletePutnik(Putnik putnik) => Delete(putnik);

        public async Task<IEnumerable<Putnik>> GetAllPutnike() => await SelectAll().ToListAsync();

        public async Task<Putnik> GetPutnikByID(int id) => await SelectByCondition(putnik => putnik.PutnikID == id).FirstOrDefaultAsync();
    }
}


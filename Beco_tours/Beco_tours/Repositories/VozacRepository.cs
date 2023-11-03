using System;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Models;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Repositories
{
    public class VozacRepository : BaseRepository<Vozac>, IVozacRepository
    {
        public VozacRepository(ApplicationDbContext context) : base(context) { }

        public void CreateVozac(Vozac vozac) => Create(vozac);

        public void UpdateVozac(Vozac vozac) => Update(vozac);

        public void DeleteVozac(Vozac vozac) => Delete(vozac);

        public async Task<IEnumerable<Vozac>> GetAllVozace() => await SelectAll().ToListAsync();

        public async Task<Vozac> GetVozacByID(int id) => await SelectByCondition(vozac => vozac.VozacID == id).FirstOrDefaultAsync();
    }
}


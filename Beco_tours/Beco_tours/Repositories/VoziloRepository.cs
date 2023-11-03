using System;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Models;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Repositories
{
    public class VoziloRepository : BaseRepository<Vozilo>, IVoziloRepository
    {
        public VoziloRepository(ApplicationDbContext context) : base(context) { }

        public void CreateVozilo(Vozilo vozilo) => Create(vozilo);

        public void UpdateVozilo(Vozilo vozilo) => Update(vozilo);

        public void DeleteVozilo(Vozilo vozilo) => Delete(vozilo);

        public async Task<IEnumerable<Vozilo>> GetAllVozila() => await SelectAll().ToListAsync();

        public async Task<Vozilo> GetVoziloByID(int id) => await SelectByCondition(vozilo => vozilo.VoziloID == id).FirstOrDefaultAsync();
    }
}


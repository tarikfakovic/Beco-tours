using System;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Models;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Repositories
{
    public class RezervacijaRepository : BaseRepository<Rezervacija>, IRezervacijaRepository
    {
        public RezervacijaRepository(ApplicationDbContext context) : base(context) { }

        public void CreateRezervacija(Rezervacija rezervacija) => Create(rezervacija);

        public void UpdateRezervacija(Rezervacija rezervacija) => Update(rezervacija);

        public void DeleteRezervacija(Rezervacija rezervacija) => Delete(rezervacija);

        /*
                public async Task<IEnumerable<Rezervacija>> GetAllRezervacije() => await SelectAll().ToListAsync();

                public async Task<Rezervacija> GetRezervacijaByID(int id) => await SelectByCondition(rezervacija => rezervacija.RezervacijaID == id).FirstOrDefaultAsync();*/


        public async Task<IEnumerable<Rezervacija>> GetAllRezervacije()
        {
            return await SelectAll()
                .Include(t => t.Putnik)
                .Include(t => t.Tura)
                .Include(t => t.Tura.Vozac)
                .Include(t => t.Tura.Vozilo)
                .Include(t => t.Tura.PolaznaLokacija)
                .Include(t => t.Tura.ZavrsnaLokacija)

                .ToListAsync();
        }
        
        public async Task<Rezervacija> GetRezervacijaByID(int id)
        {
            return await SelectByCondition(rezervacija => rezervacija.RezervacijaID == id)
                .Include(t => t.Putnik)
                .Include(t => t.Tura)
                .Include(t => t.Tura.Vozac)
                .Include(t => t.Tura.Vozilo)
                .Include(t => t.Tura.PolaznaLokacija)
                .Include(t => t.Tura.ZavrsnaLokacija)
                .FirstOrDefaultAsync();
        }
       
        public async Task<IEnumerable<Rezervacija>> GetRezervacijaByTuraID(int id)
        {
            return await SelectByCondition(rezervacija => rezervacija.TuraID == id)
                .Include(t => t.Putnik)
                .Include(t => t.Tura)
                .ToListAsync();
        }
    }
}


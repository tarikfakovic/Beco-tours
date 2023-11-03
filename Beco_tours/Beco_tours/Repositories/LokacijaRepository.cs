using System;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Models;
using Microsoft.EntityFrameworkCore;

namespace Beco_tours.Repositories
{
    public class LokacijaRepository : BaseRepository<Lokacija>, ILokacijaRepository
    {
        public LokacijaRepository(ApplicationDbContext context) : base(context) { }

        public void CreateLokacija(Lokacija lokacija) => Create(lokacija);

        public void UpdateLokacija(Lokacija lokacija) => Update(lokacija);

        public void DeleteLokacija(Lokacija lokacija) => Delete(lokacija);

        public async Task<IEnumerable<Lokacija>> GetAllLokacije() => await SelectAll().ToListAsync();

        public async Task<Lokacija> GetLokacijaByID(int id) => await SelectByCondition(lokacija => lokacija.LokacijaID == id).FirstOrDefaultAsync();
    }
}


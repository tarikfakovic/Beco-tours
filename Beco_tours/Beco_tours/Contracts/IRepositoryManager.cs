using System;
using Beco_tours.Contracts.Repository;

namespace Beco_tours.Contracts
{
    public interface IRepositoryManager
    {
        ILokacijaRepository LokacijaRepository { get; }
        IPutnikRepository PutnikRepository { get; }
        IRezervacijaRepository RezervacijaRepository { get; }
        ITuraRepository TuraRepository { get; }
        IVozacRepository VozacRepository { get; }
        IVoziloRepository VoziloRepository { get; }
        IUnitOfWorkRepository UnitOfWorkRepository { get; }
    }
}

using System;
namespace Beco_tours.Contracts.Service
{
    public interface IServiceManager
    {
        ILokacijaService LokacijaService { get; }
        IPutnikService PutnikService { get; }
        IRezervacijaService RezervacijaService { get; }
        ITuraService TuraService { get; }
        IVozacService VozacService { get; }
        IVoziloService VoziloService { get; }
    }
}


using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Service;

namespace Beco_tours.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ILokacijaService> _lazyLokacijaService;
        private readonly Lazy<IPutnikService> _lazyPutnikService;
        private readonly Lazy<IRezervacijaService> _lazyRezervacijaService;
        private readonly Lazy<ITuraService> _lazyTuraService;
        private readonly Lazy<IVozacService> _lazyVozacService;
        private readonly Lazy<IVoziloService> _lazyVoziloService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyLokacijaService = new Lazy<ILokacijaService>(() => new LokacijaService(repositoryManager));
            _lazyPutnikService = new Lazy<IPutnikService>(() => new PutnikService(repositoryManager));
            _lazyRezervacijaService = new Lazy<IRezervacijaService>(() => new RezervacijaService(repositoryManager));
            _lazyTuraService = new Lazy<ITuraService>(() => new TuraService(repositoryManager));
            _lazyVozacService = new Lazy<IVozacService>(() => new VozacService(repositoryManager));
            _lazyVoziloService = new Lazy<IVoziloService>(() => new VoziloService(repositoryManager));
        }

        public ILokacijaService LokacijaService => _lazyLokacijaService.Value;
        public IPutnikService PutnikService => _lazyPutnikService.Value;
        public IRezervacijaService RezervacijaService => _lazyRezervacijaService.Value;
        public ITuraService TuraService => _lazyTuraService.Value;
        public IVozacService VozacService => _lazyVozacService.Value;
        public IVoziloService VoziloService => _lazyVoziloService.Value;
    }
}


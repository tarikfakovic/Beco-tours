using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Repository;
using Beco_tours.Data;
using Beco_tours.Models;

namespace Beco_tours.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ILokacijaRepository> _lazyLokacijaRepository;
        private readonly Lazy<IPutnikRepository> _lazyPutnikRepository;
        private readonly Lazy<IRezervacijaRepository> _lazyRezervacijaRepository;
        private readonly Lazy<ITuraRepository> _lazyTuraRepository;
        private readonly Lazy<IVozacRepository> _lazyVozacRepository;
        private readonly Lazy<IVoziloRepository> _lazyVoziloRepository;
        private readonly Lazy<IUnitOfWorkRepository> _lazyUnitOfWork;

        public RepositoryManager(ApplicationDbContext context)
        {
            _lazyLokacijaRepository = new Lazy<ILokacijaRepository>(() => new LokacijaRepository(context));
            _lazyPutnikRepository = new Lazy<IPutnikRepository>(() => new PutnikRepository(context));
            _lazyRezervacijaRepository = new Lazy<IRezervacijaRepository>(() => new RezervacijaRepository(context));
            _lazyTuraRepository = new Lazy<ITuraRepository>(() => new TuraRepository(context));
            _lazyVozacRepository = new Lazy<IVozacRepository>(() => new VozacRepository(context));
            _lazyVoziloRepository = new Lazy<IVoziloRepository>(() => new VoziloRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWorkRepository>(() => new UnitOfWorkRepository(context));
        }

        public ILokacijaRepository LokacijaRepository => _lazyLokacijaRepository.Value;
        public IPutnikRepository PutnikRepository => _lazyPutnikRepository.Value;
        public IRezervacijaRepository RezervacijaRepository => _lazyRezervacijaRepository.Value;
        public ITuraRepository TuraRepository => _lazyTuraRepository.Value;
        public IVozacRepository VozacRepository => _lazyVozacRepository.Value;
        public IVoziloRepository VoziloRepository => _lazyVoziloRepository.Value;
        public IUnitOfWorkRepository UnitOfWorkRepository => _lazyUnitOfWork.Value;
    }
}




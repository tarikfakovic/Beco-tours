using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Data.Dto.Rezervacija;
using Beco_tours.Models;
using Mapster;

namespace Beco_tours.Services
{
    public class RezervacijaService : IRezervacijaService
    {
        private readonly IRepositoryManager _repositoryManager;
        private ResponseDto _response;

        public RezervacijaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateRezervacija(RezervacijaCreateDto rezervacijaDto)
        {
            var rezervacija = rezervacijaDto.Adapt<Rezervacija>();
            _repositoryManager.RezervacijaRepository.CreateRezervacija(rezervacija);
            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = rezervacija;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Creating Rezervacija";
            return _response;
        }

        public async Task<ResponseDto> UpdateRezervacija(int rezervacijaID, RezervacijaUpdateDto rezervacijaDto)
        {
            var rezervacijaCheck = await _repositoryManager.RezervacijaRepository.GetRezervacijaByID(rezervacijaID);
            if (rezervacijaCheck is null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Rezervacija not found in Database";
                return _response;
            }
            var rezervacija = rezervacijaDto.Adapt<Rezervacija>();
            _repositoryManager.RezervacijaRepository.Update(rezervacija);

            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = rezervacija;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Updating Rezervacija";
            return _response;
        }

        public async Task<bool> DeleteRezervacija(int RezervacijaID)
        {
            var Rezervacija = await _repositoryManager.RezervacijaRepository.GetRezervacijaByID(RezervacijaID);
            if (Rezervacija is not null)
            {
                _repositoryManager.RezervacijaRepository.DeleteRezervacija(Rezervacija);
                return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
            }

            return false;
        }

        public async Task<IEnumerable<RezervacijaReadOnlyDto>> GetAllRezervacije()
        {
            var Rezervacijae = await _repositoryManager.RezervacijaRepository.GetAllRezervacije();
            return Rezervacijae.Adapt<IEnumerable<RezervacijaReadOnlyDto>>();
        }

        public async Task<RezervacijaReadOnlyDto> GetRezervacijaByID(int RezervacijaID)
        {
            var Rezervacija = await _repositoryManager.RezervacijaRepository.GetRezervacijaByID(RezervacijaID);
            return Rezervacija.Adapt<RezervacijaReadOnlyDto>();
        }

        public async Task<IEnumerable<PutnikReadOnlyDto>> GetPutnikByTuraID(int id)
        {
            var rezervacije = await _repositoryManager.RezervacijaRepository.GetRezervacijaByTuraID(id);
            var putnici = rezervacije.Select(putnik => putnik.Putnik).ToList();
            return putnici.Adapt<IEnumerable<PutnikReadOnlyDto>>();
        }
    }
}



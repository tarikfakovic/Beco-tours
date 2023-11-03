using System;
using Mapster;
using Beco_tours.Contracts;
using Beco_tours.Data.Dto;
using Beco_tours.Contracts.Service;
using Beco_tours.Models;
using Beco_tours.Data.Dto.Lokacija;

namespace Beco_tours.Services
{
    public class LokacijaService : ILokacijaService
    {
        private readonly IRepositoryManager _repositoryManager;
        private ResponseDto _response;

        public LokacijaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateLokacija(LokacijaCreateDto lokacijaDto)
        {
            var lokacija = lokacijaDto.Adapt<Lokacija>();
            _repositoryManager.LokacijaRepository.CreateLokacija(lokacija);
            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = lokacija;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Creating Lokacija";
            return _response;
        }

        public async Task<ResponseDto> UpdateLokacija(int lokacijaID, LokacijaUpdateDto lokacijaDto)
        {
            var lokacijaCheck = await _repositoryManager.LokacijaRepository.GetLokacijaByID(lokacijaID);
            if (lokacijaCheck is null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Lokacija not found in Database";
                return _response;
            }
            var lokacija = lokacijaDto.Adapt<Lokacija>();
            _repositoryManager.LokacijaRepository.Update(lokacija);

            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = lokacija;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Updating Lokacija";
            return _response;
        }

        public async Task<bool> DeleteLokacija(int LokacijaID)
        {
            var Lokacija = await _repositoryManager.LokacijaRepository.GetLokacijaByID(LokacijaID);
            if (Lokacija is not null)
            {
                _repositoryManager.LokacijaRepository.DeleteLokacija(Lokacija);
                return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
            }

            return false;
        }

        public async Task<IEnumerable<LokacijaReadOnlyDto>> GetAllLokacije()
        {
            var Lokacije = await _repositoryManager.LokacijaRepository.GetAllLokacije();
            return Lokacije.Adapt<IEnumerable<LokacijaReadOnlyDto>>();
        }

        public async Task<LokacijaReadOnlyDto> GetLokacijaByID(int LokacijaID)
        {
            var Lokacija = await _repositoryManager.LokacijaRepository.GetLokacijaByID(LokacijaID);
            return Lokacija.Adapt<LokacijaReadOnlyDto>();
        }
    }
}


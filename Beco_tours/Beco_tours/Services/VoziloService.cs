using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Vozilo;
using Beco_tours.Models;
using Mapster;

namespace Beco_tours.Services
{
    public class VoziloService : IVoziloService
    {
        private readonly IRepositoryManager _repositoryManager;
        private ResponseDto _response;

        public VoziloService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateVozilo(VoziloCreateDto voziloDto)
        {
            var vozilo = voziloDto.Adapt<Vozilo>();
            _repositoryManager.VoziloRepository.CreateVozilo(vozilo);
            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = vozilo;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Creating Vozilo";
            return _response;
        }

        public async Task<ResponseDto> UpdateVozilo(int voziloID, VoziloUpdateDto voziloDto)
        {
            var voziloCheck = await _repositoryManager.VoziloRepository.GetVoziloByID(voziloID);
            if (voziloCheck is null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Vozilo not found in Database";
                return _response;
            }
            var vozilo = voziloDto.Adapt<Vozilo>();
            _repositoryManager.VoziloRepository.Update(vozilo);

            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = vozilo;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Updating Vozilo";
            return _response;
        }

        public async Task<bool> DeleteVozilo(int VoziloID)
        {
            var Vozilo = await _repositoryManager.VoziloRepository.GetVoziloByID(VoziloID);
            if (Vozilo is not null)
            {
                _repositoryManager.VoziloRepository.DeleteVozilo(Vozilo);
                return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
            }

            return false;
        }

        public async Task<IEnumerable<VoziloReadOnlyDto>> GetAllVozila()
        {
            var Vozila = await _repositoryManager.VoziloRepository.GetAllVozila();
            return Vozila.Adapt<IEnumerable<VoziloReadOnlyDto>>();
        }

        public async Task<VoziloReadOnlyDto> GetVoziloByID(int VoziloID)
        {
            var Vozilo = await _repositoryManager.VoziloRepository.GetVoziloByID(VoziloID);
            return Vozilo.Adapt<VoziloReadOnlyDto>();
        }
    }
}


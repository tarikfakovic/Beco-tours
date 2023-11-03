using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Data.Dto.Rezervacija;
using Beco_tours.Data.Dto.Tura;
using Beco_tours.Models;
using Mapster;

namespace Beco_tours.Services
{
    public class TuraService : ITuraService
    {
        private readonly IRepositoryManager _repositoryManager;
        private ResponseDto _response;

        public TuraService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateTura(TuraCreateDto turaDto)
        {
            var tura = turaDto.Adapt<Tura>();
            _repositoryManager.TuraRepository.CreateTura(tura);
            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = tura;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Creating Tura";
            return _response;
        }

        public async Task<ResponseDto> UpdateTura(int turaID, TuraUpdateDto turaDto)
        {
            var turaCheck = await _repositoryManager.TuraRepository.GetTuraByID(turaID);
            if (turaCheck is null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Tura not found in Database";
                return _response;
            }
            var tura = turaDto.Adapt<Tura>();
            _repositoryManager.TuraRepository.Update(tura);

            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = tura;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Updating Tura";
            return _response;
        }

        public async Task<bool> DeleteTura(int TuraID)
        {
            var Tura = await _repositoryManager.TuraRepository.GetTuraByID(TuraID);
            if (Tura is not null)
            {
                _repositoryManager.TuraRepository.DeleteTura(Tura);
                return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
            }

            return false;
        }

        public async Task<IEnumerable<TuraReadOnlyDto>> GetAllTure()
        {
            var Ture = await _repositoryManager.TuraRepository.GetAllTure();
            return Ture.Adapt<IEnumerable<TuraReadOnlyDto>>();
        }

        public async Task<TuraReadOnlyDto> GetTuraByID(int TuraID)
        {
            var Tura = await _repositoryManager.TuraRepository.GetTuraByID(TuraID);
            return Tura.Adapt<TuraReadOnlyDto>();
        }

    }
}

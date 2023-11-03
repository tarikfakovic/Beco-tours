using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Models;
using Mapster;

namespace Beco_tours.Services
{
    public class PutnikService : IPutnikService
    {
        private readonly IRepositoryManager _repositoryManager;
        private ResponseDto _response;

        public PutnikService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreatePutnik(PutnikCreateDto putnikDto)
        {
            var putnik = putnikDto.Adapt<Putnik>();
            _repositoryManager.PutnikRepository.CreatePutnik(putnik);
            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = putnik;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Creating Putnik";
            return _response;
        }

        public async Task<ResponseDto> UpdatePutnik(int putnikID, PutnikUpdateDto putnikDto)
        {
            var putnikCheck = await _repositoryManager.PutnikRepository.GetPutnikByID(putnikID);
            if (putnikCheck is null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Putnik not found in Database";
                return _response;
            }
            var putnik = putnikDto.Adapt<Putnik>();
            _repositoryManager.PutnikRepository.Update(putnik);

            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = putnik;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Updating Putnik";
            return _response;
        }

        public async Task<bool> DeletePutnik(int PutnikID)
        {
            var Putnik = await _repositoryManager.PutnikRepository.GetPutnikByID(PutnikID);
            if (Putnik is not null)
            {
                _repositoryManager.PutnikRepository.DeletePutnik(Putnik);
                return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
            }

            return false;
        }

        public async Task<IEnumerable<PutnikReadOnlyDto>> GetAllPutnike()
        {
            var Putnike = await _repositoryManager.PutnikRepository.GetAllPutnike();
            return Putnike.Adapt<IEnumerable<PutnikReadOnlyDto>>();
        }

        public async Task<PutnikReadOnlyDto> GetPutnikByID(int PutnikID)
        {
            var Putnik = await _repositoryManager.PutnikRepository.GetPutnikByID(PutnikID);
            return Putnik.Adapt<PutnikReadOnlyDto>();
        }
    }
}

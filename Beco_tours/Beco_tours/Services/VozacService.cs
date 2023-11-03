using System;
using Beco_tours.Contracts;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Vozac;
using Beco_tours.Models;
using Mapster;

namespace Beco_tours.Services
{
    public class VozacService : IVozacService
    {
        private readonly IRepositoryManager _repositoryManager;
        private ResponseDto _response;

        public VozacService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _response = new();
        }

        public async Task<ResponseDto> CreateVozac(VozacCreateDto vozacDto)
        {
            var vozac = vozacDto.Adapt<Vozac>();
            _repositoryManager.VozacRepository.CreateVozac(vozac);
            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = vozac;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Creating Vozac";
            return _response;
        }

        public async Task<ResponseDto> UpdateVozac(int vozacID, VozacUpdateDto vozacDto)
        {
            var vozacCheck = await _repositoryManager.VozacRepository.GetVozacByID(vozacID);
            if (vozacCheck is null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Vozac not found in Database";
                return _response;
            }
            var vozac = vozacDto.Adapt<Vozac>();
            _repositoryManager.VozacRepository.Update(vozac);

            var result = await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync();
            if (result > 0)
            {
                _response.Data = vozac;
                return _response;
            }

            _response.IsSuccess = false;
            _response.DisplayMessage = "Error Updating Vozac";
            return _response;
        }

        public async Task<bool> DeleteVozac(int VozacID)
        {
            var Vozac = await _repositoryManager.VozacRepository.GetVozacByID(VozacID);
            if (Vozac is not null)
            {
                _repositoryManager.VozacRepository.DeleteVozac(Vozac);
                return await _repositoryManager.UnitOfWorkRepository.SaveChangesAsync() == 1;
            }

            return false;
        }

        public async Task<IEnumerable<VozacReadOnlyDto>> GetAllVozace()
        {
            var Vozace = await _repositoryManager.VozacRepository.GetAllVozace();
            return Vozace.Adapt<IEnumerable<VozacReadOnlyDto>>();
        }

        public async Task<VozacReadOnlyDto> GetVozacByID(int VozacID)
        {
            var Vozac = await _repositoryManager.VozacRepository.GetVozacByID(VozacID);
            return Vozac.Adapt<VozacReadOnlyDto>();
        }
    }
}


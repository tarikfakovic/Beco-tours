using System;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Vozac;

namespace Beco_tours.Contracts.Service
{
    public interface IVozacService
    {
        Task<IEnumerable<VozacReadOnlyDto>> GetAllVozace();
        Task<VozacReadOnlyDto> GetVozacByID(int vozacID);
        Task<ResponseDto> CreateVozac(VozacCreateDto vozacDto);
        Task<ResponseDto> UpdateVozac(int vozacID, VozacUpdateDto vozacDto);
        Task<bool> DeleteVozac(int vozacID);
    }
}


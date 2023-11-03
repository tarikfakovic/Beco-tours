using System;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Vozilo;

namespace Beco_tours.Contracts.Service
{
    public interface IVoziloService
    {
        Task<IEnumerable<VoziloReadOnlyDto>> GetAllVozila();
        Task<VoziloReadOnlyDto> GetVoziloByID(int voziloID);
        Task<ResponseDto> CreateVozilo(VoziloCreateDto voziloDto);
        Task<ResponseDto> UpdateVozilo(int voziloID, VoziloUpdateDto voziloDto);
        Task<bool> DeleteVozilo(int voziloID);
    }
}


using System;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Lokacija;

namespace Beco_tours.Contracts.Service
{
    public interface ILokacijaService
    {
        Task<IEnumerable<LokacijaReadOnlyDto>> GetAllLokacije();
        Task<LokacijaReadOnlyDto> GetLokacijaByID(int lokacijaID);
        Task<ResponseDto> CreateLokacija(LokacijaCreateDto lokacijaDto);
        Task<ResponseDto> UpdateLokacija(int lokacijaID, LokacijaUpdateDto lokacijaDto);
        Task<bool> DeleteLokacija(int lokacijaID);
    }
}

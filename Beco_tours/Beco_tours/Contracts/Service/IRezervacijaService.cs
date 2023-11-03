using System;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Data.Dto.Rezervacija;

namespace Beco_tours.Contracts.Service
{
    public interface IRezervacijaService
    {
        Task<IEnumerable<RezervacijaReadOnlyDto>> GetAllRezervacije();
        Task<RezervacijaReadOnlyDto> GetRezervacijaByID(int rezervacijaID);
        Task<IEnumerable<PutnikReadOnlyDto>> GetPutnikByTuraID(int turaID);
        Task<ResponseDto> CreateRezervacija(RezervacijaCreateDto rezervacijaDto);
        Task<ResponseDto> UpdateRezervacija(int rezervacijaID, RezervacijaUpdateDto rezervacijaDto);
        Task<bool> DeleteRezervacija(int rezervacijaID);
    }
}


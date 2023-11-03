using System;
using Beco_tours.Data.Dto;
using Beco_tours.Data.Dto.Tura;

namespace Beco_tours.Contracts.Service
{
    public interface ITuraService
    {
        Task<IEnumerable<TuraReadOnlyDto>> GetAllTure();
        Task<TuraReadOnlyDto> GetTuraByID(int turaID);
        Task<ResponseDto> CreateTura(TuraCreateDto turaDto);
        Task<ResponseDto> UpdateTura(int turaID, TuraUpdateDto turaDto);
        Task<bool> DeleteTura(int turaID);
    }
}


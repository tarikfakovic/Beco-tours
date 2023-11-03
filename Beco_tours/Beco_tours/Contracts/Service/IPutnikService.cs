using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Beco_tours.Data.Dto.Putnik;
using Beco_tours.Data.Dto;

namespace Beco_tours.Contracts.Service
{
    public interface IPutnikService
    {
        Task<IEnumerable<PutnikReadOnlyDto>> GetAllPutnike();
        Task<PutnikReadOnlyDto> GetPutnikByID(int putnikID);
        Task<ResponseDto> CreatePutnik(PutnikCreateDto putnikDto);
        Task<ResponseDto> UpdatePutnik(int putnikID, PutnikUpdateDto putnikDto);
        Task<bool> DeletePutnik(int putnikID);
    }
}


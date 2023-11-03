using System;
namespace Beco_tours.Contracts.Repository
{
    public interface IUnitOfWorkRepository
    {
        Task<int> SaveChangesAsync();
    }
}

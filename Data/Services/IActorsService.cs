using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actors>> GetAllAsync();
        Task<Actors> GetByIdAsync(int id);
        Task AddAsync(Actors actor);
        Task<Actors> UpdateAsync(int id, Actors newActor);
        Task DeleteAsync(int id);
    }
    
}

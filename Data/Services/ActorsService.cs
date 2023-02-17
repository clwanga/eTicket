using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class ActorsService : IActorsService
    {
        public readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context; 
        }
        public async Task AddAsync(Actors actor) //add to the database
        {
            await _context.Actors.AddAsync(actor);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id); //fetch 
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actors>> GetAllAsync() //get all available actors in the database
        {
            var result = await _context.Actors.ToListAsync();

            return result;
        }

        public async Task<Actors> GetByIdAsync(int id) //get details of an actor from the database
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Actors> UpdateAsync(int id, Actors newActor)
        {
             _context.Actors.Update(newActor);
           await _context.SaveChangesAsync();
            return newActor; 
        }
    }
}

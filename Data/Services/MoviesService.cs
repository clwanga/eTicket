using eTicket.Data.Base;
using eTicket.Data.ViewModel;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movies>, IMoviesService
    {
        private readonly AppDbContext _context;


        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movies> GetMoviesByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actor_Movie).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownVM()
            {

                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }
    }
}

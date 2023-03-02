using eTicket.Data.Base;
using eTicket.Data.ViewModel;
using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movies>
    {
        Task<Movies> GetMoviesByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdownValues();
        Task AddNewMovieAsync(NewMovieVM data);
    }
}

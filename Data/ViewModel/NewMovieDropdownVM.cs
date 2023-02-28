using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.ViewModel
{
    public class NewMovieDropdownVM
    {
        public NewMovieDropdownVM()
        {
            Producers = new List<Producers>();
            Cinemas = new List<Cinemas>();
            Actors = new List<Actors>();
        }
        public List<Producers> Producers { get; set; }
        public List<Cinemas> Cinemas { get; set; }
        public List<Actors> Actors { get; set; }

    }
}

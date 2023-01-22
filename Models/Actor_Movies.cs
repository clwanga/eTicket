using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Actor_Movies
    {
        public int MovieID { get; set; }
        public Movies Movie { get; set; }
        public int ActorID { get; set; }
        public Actors Actor { get; set; }
    }
}

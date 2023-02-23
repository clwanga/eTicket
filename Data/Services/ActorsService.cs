using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actors>, IActorsService
    {
        public readonly AppDbContext _context;

        public ActorsService(AppDbContext context): base(context) { }
    }
}

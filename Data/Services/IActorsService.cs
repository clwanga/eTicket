using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actors> GetAll();
        Actors GetById(int id);
        void Add(Actors actor);
        Actors Update(int id, Actors newActor);
        void Delete(int id);
    }
    
}

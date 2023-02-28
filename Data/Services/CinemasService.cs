using eTicket.Data.Base;
using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinemas>, ICinemasService
    {
            
        public CinemasService(AppDbContext context):base(context)
        {

        }
    }
}

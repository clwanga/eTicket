using eTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class ProducersController : Controller
    {
        public readonly AppDbContext _context; //database linking file

        public ProducersController(AppDbContext context) //constructor
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducersData = await _context.Producers.ToListAsync();
            return View(allProducersData);
        }
    }
}

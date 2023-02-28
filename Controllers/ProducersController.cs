using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
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
        public readonly IProducersService _service; //database linking file

        public ProducersController(IProducersService service) //constructor
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducersData = await _service.GetAllAsync();

            return View(allProducersData);
        }

        //details part
        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        //edit action to view details to edit
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        //edit action that processes the update request
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")]Producers producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            else
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
        }

        //delete view controller action 
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return View("NotFound");
            return View(result);
        }

        //handles the delete action
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //create producer
        public IActionResult AddProducer()
        {
            return View();
        }

        //action that handles http request to add user to db
        [HttpPost]
        public async Task<IActionResult> AddProducer(Producers producer)
        {
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
    }
}

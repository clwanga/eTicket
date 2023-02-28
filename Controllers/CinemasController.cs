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
    public class CinemasController : Controller
    {
        public readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemaData = await _service.GetAllAsync();
            return View(allCinemaData);
        }

        //controller that handles the edit view
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View("NotFound");
            }

        }

        //controller that handles the edit request
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinemas cinema)
        {
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //delete view 
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View("NotFound");
            }
        }

        //action to handle the post request
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

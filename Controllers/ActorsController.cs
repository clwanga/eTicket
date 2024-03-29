﻿using eTicket.Data;
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
    public class ActorsController : Controller
    {
        public readonly IActorsService _service;

        public ActorsController(IActorsService service) //created constructor to initialize service
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActorsData = await _service.GetAllAsync();
            return View(allActorsData);
        }

        //Get: Actors/Create

        public IActionResult Create() //shows the actors details
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actors actor) //handles the httprequest 
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        //Get: Actors/Edit

        public async Task<IActionResult> Edit(int id) //shows the details
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actors actor) //handles the httprequest also checks the actor id against the updated values
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete

        public async Task<IActionResult> Delete(int id) //shows the details
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id) //handles the httprequest also checks the actor id against the updated values
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

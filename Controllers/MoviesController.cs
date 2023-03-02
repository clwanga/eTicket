﻿using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMoviesData = await _service.GetAllAsync(n => n.Cinema);
            return View(allMoviesData);
        }

        //Get: Details/id
        public async Task<IActionResult> Details(int id)
        {
           var movieDetails = await _service.GetMoviesByIdAsync(id);
           return View(movieDetails);
        }

        //create new movie controller for the view
        public async Task<IActionResult> Create()
        {
            var movieDropdownValues = await _service.GetNewMovieDropdownValues();
 
            ViewBag.Cinemas = new SelectList(movieDropdownValues.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownValues.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "FullName");
            return View();
        }

        //create movie that handles the http request to add a new movie 
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownValues = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropdownValues.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownValues.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "FullName");

                return View("NotFound");
            }
            else
            {

                await _service.AddNewMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
        }

        //edit movie controller
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _service.GetMoviesByIdAsync(id);

            return View(result);
        }
    }
}

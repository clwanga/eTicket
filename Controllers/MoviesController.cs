using eTicket.Data;
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
        private readonly IMoviesService _service; //variable declaration

        public MoviesController(IMoviesService service) //constructor to initialize
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMoviesData = await _service.GetAllAsync(n => n.Cinema);
            return View(allMoviesData);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMoviesData = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMoviesData.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index",allMoviesData);
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

        //Get: movies/edit/1 
        public async Task<IActionResult> Edit(int id)
        {
            //get the dropdown values
            var movieDropdownValues = await _service.GetNewMovieDropdownValues();
            ViewBag.Cinemas = new SelectList(movieDropdownValues.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownValues.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "FullName");


            //get movie details by id
            var result = await _service.GetMoviesByIdAsync(id);

            if(result == null)
            {
                return View("NotFound");
            }


            //create the response 
            var response = new NewMovieVM()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                ImageURL = result.ImageURL,
                MovieCategory = result.MovieCategory,
                CinemaId = result.CinemaId,
                ProducerId = result.ProducerId,
                ActorIds = result.Actor_Movie.Select(n => n.ActorID).ToList()
            };

            //pass the response to the view
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

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

                await _service.UpdateNewMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

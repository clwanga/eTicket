using eTicket.Data;
using eTicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class NewMovieVM
    {
        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Movie name cannot be empty")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }

        [Display(Name = "Movie price")]
        [Required(ErrorMessage = "Price cannot be empty")]
        public double Price { get; set; }

        [Display(Name = "Movie URL")]
        [Required(ErrorMessage = "Movie URL cannot be empty")]
        public string ImageURL { get; set; }

        [Display(Name = "Movie start date")]
        [Required(ErrorMessage = "Movie start date cannot be empty")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie end date")]
        [Required(ErrorMessage = "Movie end date cannot be empty")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select Category")]
        [Required(ErrorMessage = "Movie category cannot be empty")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select actor")]
        [Required(ErrorMessage = "Actor cannot be empty")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select cinema")]
        [Required(ErrorMessage = "Cinema cannot be empty")]
        public int CinemaId { get; set; }

        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "Producer cannot be empty")]
        public int ProducerId { get; set; }
    }
}

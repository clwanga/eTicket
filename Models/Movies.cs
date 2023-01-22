using eTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //definition of relationships

        //joined tables (Actor and movies)
        public List<Actor_Movies> Actor_Movie { get; set; }

        //cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinemas Cinema { get; set; }

        //producers
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producers Producer { get; set; }
    }
}

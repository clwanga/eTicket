using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        //movie relationship
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies Movie { get; set; }


        //Order relationship
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }


    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace freelanceMarketplace.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int GigId { get; set; }
        public Gig? Gig { get; set; }

        public int BuyerId { get; set; }
        public User? Buyer { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
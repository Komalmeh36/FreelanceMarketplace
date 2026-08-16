using System.Collections.Generic;

namespace freelanceMarketplace.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        // One Gig can have many Reviews
        public ICollection<Review>? Reviews { get; set; }
    }
}
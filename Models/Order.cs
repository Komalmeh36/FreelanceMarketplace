namespace freelanceMarketplace.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public int GigId { get; set; }
        public Gig Gig { get; set; }

        public int BuyerId { get; set; }
        public User Buyer { get; set; }
    }
}
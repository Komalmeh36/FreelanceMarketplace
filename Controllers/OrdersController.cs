using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using freelanceMarketplace.Data;
using freelanceMarketplace.Models;
using System.Linq;

namespace freelanceMarketplace.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Place Order
        public IActionResult Create(int id)
        {
            var gig = _context.Gigs.FirstOrDefault(g => g.Id == id);

            if (gig == null)
            {
                return Content("Gig not found");
            }

            var buyerId = HttpContext.Session.GetInt32("UserId");

            if (buyerId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var order = new Order
            {
                GigId = gig.Id,
                BuyerId = buyerId.Value,
                Status = "Pending"
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        // Show ALL orders
        public IActionResult List()
        {
            var orders = _context.Orders
                .Include(o => o.Gig)
                .Include(o => o.Buyer)
                .ToList();

            return View(orders);
        }

        // Complete Order
        public IActionResult Complete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                order.Status = "Completed";
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }

        // Cancel Order
        public IActionResult Cancel(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                order.Status = "Cancelled";
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }

        // Show only current buyer's orders
        public IActionResult MyOrders()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            var orders = _context.Orders
                .Include(o => o.Gig)
                .Include(o => o.Buyer)
                .Where(o => o.BuyerId == userId.Value)
                .ToList();

            return View(orders);
        }
    }
}
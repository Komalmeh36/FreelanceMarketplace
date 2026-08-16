using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using freelanceMarketplace.Data;
using System.Linq;

namespace freelanceMarketplace.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Basic statistics
            ViewBag.TotalUsers = _context.Users.Count();

            ViewBag.TotalGigs = _context.Gigs.Count();

            ViewBag.TotalOrders = _context.Orders.Count();

            ViewBag.PendingOrders =
                _context.Orders.Count(o => o.Status == "Pending");

            ViewBag.CompletedOrders =
                _context.Orders.Count(o => o.Status == "Completed");

            ViewBag.CancelledOrders =
                _context.Orders.Count(o => o.Status == "Cancelled");


            // Get the 5 most recent orders
            var recentOrders = _context.Orders
                .Include(o => o.Gig)
                .Include(o => o.Buyer)
                .OrderByDescending(o => o.Id)
                .Take(5)
                .ToList();

            ViewBag.RecentOrders = recentOrders;


            return View();
        }
    }
}
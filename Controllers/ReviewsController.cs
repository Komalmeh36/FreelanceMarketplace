using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using freelanceMarketplace.Data;
using freelanceMarketplace.Models;
using System.Linq;

namespace freelanceMarketplace.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Review Form
        public IActionResult Create(int gigId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.GigId = gigId;

            return View();
        }

        // Save Review
        [HttpPost]
        public IActionResult Create(Review review)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            review.BuyerId = userId.Value;

            _context.Reviews.Add(review);
            _context.SaveChanges();

            TempData["Success"] = "Review submitted successfully.";

            return RedirectToAction("List", "Gigs");
        }

        // Show Reviews of a Gig
        public IActionResult List(int gigId)
        {
            var reviews = _context.Reviews
                .Include(r => r.Buyer)
                .Where(r => r.GigId == gigId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            ViewBag.GigId = gigId;

            return View(reviews);
        }
    }
}
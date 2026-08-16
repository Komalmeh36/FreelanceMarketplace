using Microsoft.AspNetCore.Mvc;
using freelanceMarketplace.Data;
using freelanceMarketplace.Models;
using System.Linq;

namespace freelanceMarketplace.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // SHOW ALL GIGS
        public IActionResult List(string searchTerm)
        {
            var gigs = _context.Gigs.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                gigs = gigs.Where(g =>
                    g.Title.Contains(searchTerm) ||
                    g.Description.Contains(searchTerm));
            }

            ViewBag.SearchTerm = searchTerm;

            return View(gigs.ToList());
        }

        // SHOW GIG DETAILS
        public IActionResult Details(int id)
        {
            var gig = _context.Gigs.Find(id);

            if (gig == null)
            {
                return NotFound();
            }

            return View(gig);
        }

        // CREATE GIG PAGE
        public IActionResult Create()
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Seller")
            {
                TempData["Error"] = "Only Sellers can create gigs.";
                return RedirectToAction("List");
            }

            return View();
        }

        // SAVE GIG
        [HttpPost]
        public IActionResult Create(Gig gig)
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Seller")
            {
                TempData["Error"] = "Only Sellers can create gigs.";
                return RedirectToAction("List");
            }

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Users");
            }

            gig.UserId = userId.Value;

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            TempData["Success"] = "Gig created successfully.";

            return RedirectToAction("List");
        }

        // EDIT GIG PAGE
        public IActionResult Edit(int id)
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Seller")
            {
                return RedirectToAction("List");
            }

            var gig = _context.Gigs.Find(id);

            if (gig == null)
            {
                return NotFound();
            }

            return View(gig);
        }

        // SAVE EDITED GIG
        [HttpPost]
        public IActionResult Edit(Gig gig)
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Seller")
            {
                return RedirectToAction("List");
            }

            _context.Gigs.Update(gig);
            _context.SaveChanges();

            TempData["Success"] = "Gig updated successfully.";

            return RedirectToAction("List");
        }

        // DELETE GIG
        public IActionResult Delete(int id)
        {
            var role = HttpContext.Session.GetString("UserRole");

            if (role != "Seller")
            {
                return RedirectToAction("List");
            }

            var gig = _context.Gigs.Find(id);

            if (gig != null)
            {
                _context.Gigs.Remove(gig);
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}
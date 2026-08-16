using Microsoft.AspNetCore.Mvc;
using freelanceMarketplace.Data;
using freelanceMarketplace.Models;
using freelanceMarketplace.ViewModels;
using System.Linq;

namespace freelanceMarketplace.Controllers
{
public class UsersController : Controller
{
private readonly ApplicationDbContext _context;


    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Registration Form
    public IActionResult Register()
    {
        return View();
    }

    // Save User
    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        return View(user);
    }

    // Login Form
    public IActionResult Login()
    {
        return View();
    }

    // Check Login
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        var user = _context.Users.FirstOrDefault(u =>
            u.Email == model.Email &&
            u.Password == model.Password);

        if (user != null)
        {
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Dashboard");
        }

        ViewBag.Error = "Invalid Email or Password";
        return View(model);
    }

    // Dashboard
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetString("UserName") == null)
        {
            return RedirectToAction("Login");
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.UserRole = HttpContext.Session.GetString("UserRole");

        return View();
    }

    // Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Login");
    }

    // Show All Users
    public IActionResult List()
    {
        var users = _context.Users.ToList();
        return View(users);
    }

    // EDIT GET
    public IActionResult Edit(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // EDIT POST
    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Update(user);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        return View(user);
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            TempData["Error"] = "User not found.";
            return RedirectToAction("List");
        }

        bool hasOrders = _context.Orders.Any(o => o.BuyerId == id);

        if (hasOrders)
        {
            TempData["Error"] = "Cannot delete this user because they have existing orders.";
            return RedirectToAction("List");
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        TempData["Success"] = "User deleted successfully.";

        return RedirectToAction("List");
    }
}


}

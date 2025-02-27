using Microsoft.AspNetCore.Mvc;
using SimpleMenu.Data;

namespace SimpleMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly SimpleMenuDbContext _context;

        public MenuController(SimpleMenuDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexMenu()
        {
            var allDish = _context.TblDish.ToList();
            return View(allDish);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}

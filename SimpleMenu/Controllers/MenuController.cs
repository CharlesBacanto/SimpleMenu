using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult IndexMenu(string? searchTag)
        {   
            var searchInDb = _context.TblDish.Where(searchData => searchData.name.Contains(searchTag));
            var searchDish = searchInDb.ToList();
            if (!string.IsNullOrEmpty(searchTag))
            {
                return View(searchDish);
            }
            var allDish = _context.TblDish.ToList();
            return View(allDish);
        }
        public IActionResult Details(int id)
        {
            var dishIdInDb = _context.TblDish
                .Include(di => di.DishIngredient)
                .ThenInclude(i => i.Ingredient)
                .SingleOrDefault(dishId => dishId.id == id);
            return View(dishIdInDb);
        }
    }
}

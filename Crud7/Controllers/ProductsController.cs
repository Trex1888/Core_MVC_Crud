using Crud7.Models;
using Crud7.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.OrderBy(p => p.Name).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductsViewModel productsView)
        {
            if (productsView.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image is required.");
            }

            if (!ModelState.IsValid)
            {
                return View(productsView);
            }

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        //public async Task<IActionResult> Index()
        //{
        //    IEnumerable<Club> clubs = await _clubRepository.GetAll();
        //    return View(clubs);
        //}

    }
}

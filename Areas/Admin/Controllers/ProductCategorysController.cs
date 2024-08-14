using Microsoft.AspNetCore.Mvc;
using WebsiteTMDT.Areas.Admin.Models.EF;
using WebsiteTMDT.Data;

namespace WebsiteTMDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategorysController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductCategorysController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var items = _db.ProductCategories;
            return View(items);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            model.CreateDate = DateTime.Now;
            model.ModifierDate = DateTime.Now;
            model.Alias = WebsiteTMDT.Areas.Admin.Models.Common.Filter.FilterChar(model.Title);
            _db.ProductCategories.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

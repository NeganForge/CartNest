using CartNest.Models.Entities;
using CartNest.Repositories;
using CartNest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CartNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(
            IProductService productService,
            ICategoryRepository categoryRepository)
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
        }

        // ==========================
        // INDEX
        // ==========================

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        // ==========================
        // CREATE - GET
        // ==========================

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(
                await _categoryRepository.GetAllAsync(),
                "Id",
                "Name");

            return View();
        }

        // ==========================
        // CREATE - POST
        // ==========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                await _categoryRepository.GetAllAsync(),
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // ==========================
        // EDIT - GET
        // ==========================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(
                await _categoryRepository.GetAllAsync(),
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // ==========================
        // EDIT - POST
        // ==========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                await _categoryRepository.GetAllAsync(),
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // ==========================
        // DELETE - GET
        // ==========================

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // ==========================
        // DELETE - POST
        // ==========================

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
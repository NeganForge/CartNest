using Microsoft.AspNetCore.Mvc;

[Area("User")]
public class ProductController : Controller
{
    private readonly IUserProductService _userProductService;

    public ProductController(
        IUserProductService userProductService)
    {
        _userProductService = userProductService;
    }

    [HttpGet]
    public async Task<IActionResult> Search(string keyword)
    {
        var products =
            await _userProductService.SearchAsync(keyword);

        return Json(products);
    }

    [HttpGet]
    public async Task<IActionResult> SearchResults(string keyword)
    {
        var products =
            await _userProductService.SearchAsync(keyword);

        ViewBag.Keyword = keyword;

        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product =
            await _userProductService.GetByIdAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }
}
using BaseCoffee.BLL.DTOs;
using BaseCoffee.BLL.Managers.Abstract;
using BaseCoffee.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseCoffee.UI.Controllers
{

    public class ProductController : Controller
    {
        private readonly IGenericManager<ProductDTO, Product> _productManager;
        private readonly IGenericManager<CategoryDTO, Category> _categoryManager;

        public ProductController(IGenericManager<CategoryDTO, Category> categoryManager, IGenericManager<ProductDTO, Product> productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }
        public IActionResult Index()
        {
            var prodcuts = _productManager.GetAll();
            var productDtos = prodcuts.Select(
                p => new
                {
                    p.Id,
                    p.CategoryID,
                    p.Name,
                    p.Price,
                    p.Description,
                    p.StockQuantity,
                    categoryName = _categoryManager.Find(p.CategoryID)?.Name
                }
                ).ToList();
            return View(productDtos);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryManager.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                _productManager.Add(productDTO);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _categoryManager.GetAll();

            return View(productDTO);
        }

        public IActionResult Edit(int id)
        {
            var product = _productManager.Find(id);
            ViewBag.Categories = _productManager.GetAll();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductDTO productDTO)
        {
            _productManager.Update(productDTO);
            ViewBag.Categories = _productManager.GetAll();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _productManager.Find(id);
            _productManager.Remove(product);
            return RedirectToAction("Index");
        }

    }
}
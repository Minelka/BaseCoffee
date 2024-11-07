using BaseCoffee.BLL.DTOs;
using BaseCoffee.BLL.Managers.Abstract;
using BaseCoffee.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BaseCoffee.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericManager<CategoryDTO, Category> _categoryManager;

        public CategoryController(IGenericManager<CategoryDTO, Category> categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            var categories = _categoryManager.GetAll();
            return View(categories);
        }
        
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDTO)
        {
            _categoryManager.Add(categoryDTO);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryManager.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(CategoryDTO categoryDTO)
        {
            _categoryManager.Update(categoryDTO);
            return RedirectToAction("Index");
        }
     
        public IActionResult Delete(int id)
        {
            var category = _categoryManager.Find(id);
            _categoryManager.Remove(category);
            return RedirectToAction("Index");
        }
    }
}

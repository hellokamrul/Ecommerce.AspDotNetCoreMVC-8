using Ecommerce.Models.Models;
using Ecommerce.MVC.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
          List<Category> categoryList  = _context.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
            }
                if (ModelState.IsValid)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    TempData["success"] = "Category Created Successfully...";
                    return RedirectToAction("Index");
                }
            
            return View();
        }

        public IActionResult Edit(int id)
        {
            Category? category = _context.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Category data)
        {
            
            if (data != null)
            {
                if (data.Name == data.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name");
                }
                _context.Categories.Update(data);
                _context.SaveChanges();
                TempData["success"] = "Category Update Successfully...";
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int? id)
        {
            Category? data =_context.Categories.FirstOrDefault(x => x.Id == id);
            if(data != null)
            {

                return View(data);
            }
            return NotFound();
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _context.Categories.FirstOrDefault(x=>x.Id == id); 
            if (obj == null) 
            {
                return NotFound();  
            }
            _context.Remove(obj);   
            _context.SaveChanges();
            TempData["success"] = "Category Deleted Successfully...";
            return RedirectToAction("Index");
        }
    }
}

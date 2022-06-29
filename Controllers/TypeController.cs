using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wow.Data;
using wow.Models;
using wow.Models.ViewModels;

namespace wow.Controllers
{
    public class TypeController : Controller
    {
        private readonly ApplicationDbContext _db;
      
       [BindProperty]
        public TypeViewModel TypeVM{ get; set; }

        public TypeController(ApplicationDbContext db)
        {
            
            _db = db;
            TypeVM = new TypeViewModel()
            {
               Items = _db.Items.ToList(),
               Type = new Models.Type()
            };
        
        }
         
         
        [HttpGet]
        public IActionResult Index()
        {
         var type = _db.Types.Include(m => m.Item);
            return View(type);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(TypeVM);
        }
        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreatePost()
        {
            if(ModelState.IsValid)
            {
                _db.Types.Add(TypeVM.Type);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TypeVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TypeVM.Type = _db.Types.Include(m=>m.Item).SingleOrDefault(m=> m.Id == id);
            if(TypeVM.Type == null)

            {
                return NotFound();
            }
            
           return View(TypeVM);
        }
         [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost()
        {
            if(ModelState.IsValid)
            {
                _db.Types.Update(TypeVM.Type);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TypeVM);
        }
      [HttpGet]
        public IActionResult Delete(int id)
        {
            TypeVM.Type = _db.Types.Include(m=>m.Item).SingleOrDefault(m=> m.Id == id);
            if(TypeVM.Type == null)

            {
                return NotFound();
            }
            
           return View(TypeVM);

        }

         [HttpPost]

        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {


            var type = _db.Types.Find(id);
            if(type == null)
           
            {
                     return NotFound();
       
            }

             _db.Types.Remove(type);
            _db.SaveChanges();
                return RedirectToAction("Index");
          
        }

    }
}
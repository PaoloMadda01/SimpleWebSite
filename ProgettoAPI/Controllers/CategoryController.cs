using Microsoft.AspNetCore.Mvc;
using ProgettoAPI.Data;
using ProgettoAPI.Models;

namespace ProgettoAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        //POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]      //To help and prevent the cross site request forgery attack
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The dislayOrder Exacrly match the Name.");
            }
            if (ModelState.IsValid)     //per evitare l'eccezione in cui quancuno non scriva niente 
            {
                _db.Categories.Add(obj);        //per aggiungere i dati di obj nel database
                _db.SaveChanges();              //per salvare tutte le modifiche
                TempData["success"] = "Category added successfully";          //Salvato questo messaggio nel tempData con la key "success" 
                return RedirectToAction("Index");
            }
            return View(obj);
        }



                                        //EDIT          EDIT                EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();

            }
            var categoryFromDb = _db.Categories.Find(id);            //_db.Categories questo visualizzerà tutte le tabelle del db
                                                                     //_db.Categories.SingleOrDefault restituisce un solo elemento, empty se non lo trova
                                                                     //_db.Categories.Single dà un'eccezione se non trova nessuno di questi
                                                                     //_db.Categories.find cerca in base alla chiave primaria -> id
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.id==id); //u => u è il valore di default id==id è il valore

            if(categoryFromDb== null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]      //To help and prevent the cross site request forgery attack
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The dislayOrder Exacrly match the Name.");
            }
            if (ModelState.IsValid)     //per evitare l'eccezione in cui quancuno non scriva niente 
            {
                _db.Categories.Update(obj);        //per aggiungere/aggiornare i dati di obj nel database
                _db.SaveChanges();              //per salvare tutte le modifiche
                TempData["success"] = "Category updated successfully";          //Salvato questo messaggio nel tempData con la key "success"
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        

            //DELETE
            public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();

                }
                var categoryFromDb = _db.Categories.Find(id);            
                                                                    
                if (categoryFromDb == null)
                {
                    return NotFound();
                }

                return View(categoryFromDb);
            }

        


            //POST action method
            [HttpPost]
            [ValidateAntiForgeryToken]      //To help and prevent the cross site request forgery attack
            public IActionResult DeletePost(int? id)
            {

                var obj = _db.Categories.Find(id);

                if (id == null)
                {
                    return NotFound();

                }

                _db.Categories.Remove(obj);        //per aggiungere/aggiornare i dati di obj nel database
                    _db.SaveChanges();              //per salvare tutte le modifiche
                TempData["success"] = "Category deleted successfully";          //Salvato questo messaggio nel tempData con la key "success"
                return RedirectToAction("Index");
            
            }
    }
}

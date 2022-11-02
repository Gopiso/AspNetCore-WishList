

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;


namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context; 
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
       

        public IActionResult Index()
        {
            var listitems=_context.Items.ToList();       
            return View("Index",listitems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }       
        [HttpPost]  
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var item=_context.Items.FirstOrDefault(x => x.Id == Id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }

    }
}

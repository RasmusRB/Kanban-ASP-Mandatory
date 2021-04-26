using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kanban.Data;
using Kanban.Models;
using Kanban.Services;

namespace Kanban.Controllers
{
    
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBoardRepository _repo;

        public ItemsController(ApplicationDbContext context, IBoardRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // redirects to board view
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Board");
        }

        // returns create view
        public IActionResult Create()
        {
            return View("Create");
        }

        // creates an item
        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(item);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Create));
        }

        // updates an item, currently not working correctly

        //[HttpGet]
        //public async Task<IActionResult> UpdateItem(int? itemId)
        //{
        //    if (itemId == null)
        //    {
        //        return NotFound();
        //    }

        //    var item = await _context.Items.FindAsync(itemId);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("UpdateItem");
        //}

        // deletes an item from id
        [HttpPost]
        public IActionResult Delete(int itemId)
        {
            var success = _repo.DeleteItem(itemId);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }
    }
}


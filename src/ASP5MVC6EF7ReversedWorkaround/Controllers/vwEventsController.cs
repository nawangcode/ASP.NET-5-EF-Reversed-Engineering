using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ASP5MVC6EF7ReversedWorkaround.Models;

namespace ASP5MVC6EF7ReversedWorkaround.Controllers
{
    public class vwEventsController : Controller
    {
        private R5Context _context;

        public vwEventsController(R5Context context)
        {
            _context = context;    
        }

        // GET: vwEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.R5Events.ToListAsync());
        }

        // GET: vwEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            vwEvent vwEvent = await _context.R5Events.SingleAsync(m => m.idEvent == id);
            if (vwEvent == null)
            {
                return HttpNotFound();
            }

            return View(vwEvent);
        }

        // GET: vwEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vwEvents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(vwEvent vwEvent)
        {
            if (ModelState.IsValid)
            {
                _context.R5Events.Add(vwEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vwEvent);
        }

        // GET: vwEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            vwEvent vwEvent = await _context.R5Events.SingleAsync(m => m.idEvent == id);
            if (vwEvent == null)
            {
                return HttpNotFound();
            }
            return View(vwEvent);
        }

        // POST: vwEvents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(vwEvent vwEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Update(vwEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vwEvent);
        }

        // GET: vwEvents/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            vwEvent vwEvent = await _context.R5Events.SingleAsync(m => m.idEvent == id);
            if (vwEvent == null)
            {
                return HttpNotFound();
            }

            return View(vwEvent);
        }

        // POST: vwEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            vwEvent vwEvent = await _context.R5Events.SingleAsync(m => m.idEvent == id);
            _context.R5Events.Remove(vwEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

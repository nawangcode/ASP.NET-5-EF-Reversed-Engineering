using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ASP5MVC6EF7ReversedWorkaround.Models;

namespace ASP5MVC6EF7ReversedWorkaround.Controllers
{
    [Produces("application/json")]
    [Route("api/vwEventsApi")]
    public class vwEventsApiController : Controller
    {
        private R5Context _context;

        public vwEventsApiController(R5Context context)
        {
            _context = context;
        }

        // GET: api/vwEventsApi
        [HttpGet]
        public IEnumerable<vwEvent> GetR5Events()
        {
            return _context.R5Events;
        }

        // GET: api/vwEventsApi/5
        [HttpGet("{id}", Name = "GetvwEvent")]
        public async Task<IActionResult> GetvwEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            vwEvent vwEvent = await _context.R5Events.SingleAsync(m => m.idEvent == id);

            if (vwEvent == null)
            {
                return HttpNotFound();
            }

            return Ok(vwEvent);
        }

        // PUT: api/vwEventsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutvwEvent([FromRoute] int id, [FromBody] vwEvent vwEvent)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != vwEvent.idEvent)
            {
                return HttpBadRequest();
            }

            _context.Entry(vwEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vwEventExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/vwEventsApi
        [HttpPost]
        public async Task<IActionResult> PostvwEvent([FromBody] vwEvent vwEvent)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.R5Events.Add(vwEvent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (vwEventExists(vwEvent.idEvent))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetvwEvent", new { id = vwEvent.idEvent }, vwEvent);
        }

        // DELETE: api/vwEventsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletevwEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            vwEvent vwEvent = await _context.R5Events.SingleAsync(m => m.idEvent == id);
            if (vwEvent == null)
            {
                return HttpNotFound();
            }

            _context.R5Events.Remove(vwEvent);
            await _context.SaveChangesAsync();

            return Ok(vwEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vwEventExists(int id)
        {
            return _context.R5Events.Count(e => e.idEvent == id) > 0;
        }
    }
}
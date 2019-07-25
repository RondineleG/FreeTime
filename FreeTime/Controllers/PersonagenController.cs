using FreeTime.Data;
using FreeTime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace FreeTime.Controllers
{
    public class PersonagenController : Controller
    {
        private readonly PersonagenContext _context;

        public PersonagenController(PersonagenContext context)
        {
            _context = context;
        }

        // GET: Personagen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personagens.ToListAsync());
        }

        // GET: Personagen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personagen = await _context.Personagens
                .SingleOrDefaultAsync(m => m.Id == id);
            if (personagen == null)
            {
                return NotFound();
            }

            return View(personagen);
        }

        // GET: Personagen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personagen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Criador,Ano,ImageUrl,Descricao")] Personagen personagen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personagen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personagen);
        }

        // GET: Personagen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Personagens.SingleOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Personagen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Criador,Ano,ImageUrl,Descricao")] Personagen personagen)
        {
            if (id != personagen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personagen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(personagen.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personagen);
        }

        // GET: Personagen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Personagens
                .SingleOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Personagen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Personagens.SingleOrDefaultAsync(m => m.Id == id);
            _context.Personagens.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Personagens.Any(e => e.Id == id);
        }
    }
}

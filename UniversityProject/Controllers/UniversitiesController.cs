using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Data;
using UniversityProject.Models;
using UniversityProject.ViewModels;

namespace UniversityProject.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly AppDbContext _context;

        public UniversitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Universities
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.Universities != null ?
                        View(await _context.Universities.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Universities'  is null.");
        }

        // GET: Universities/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Universities == null)
        //    {
        //        return NotFound();
        //    }

        //    var university = await _context.Universities
        //        .Include(u => u.Departments)
        //        .Include(u => u.Faculties)
        //        .Include(u => u.Followers)
        //        .FirstOrDefaultAsync(m => m.UniversityId == id);

        //    if (university == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(university);
        //}

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .Include(u => u.Departments)
                .ThenInclude(d => d.Courses)
                .Include(u => u.Faculties)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(m => m.UniversityId == id);

            if (university == null)
            {
                return NotFound();
            }

            var viewModel = new UniversityDetailsViewModel
            {
                University = university,
                Departments = university.Departments,
                Courses = university.Departments.SelectMany(d => d.Courses).ToList(),
                Faculties = university.Faculties
            };

            return View(viewModel);
        }



        // GET: Universities/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversityId,Name,Description,Location,ContactEmail,ContactPhone,Website,CreatedDate")] University university)
        {
            if (ModelState.IsValid)
            {
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }


        // GET: Universities/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("UniversityId,Name,Description,Location,ContactEmail,ContactPhone,Website,CreatedDate")] University university)
        {
            if (id != university.UniversityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.UniversityId))
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
            return View(university);
        }

        // GET: Universities/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .FirstOrDefaultAsync(m => m.UniversityId == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Universities == null)
            {
                return Problem("Entity set 'AppDbContext.Universities'  is null.");
            }
            var university = await _context.Universities.FindAsync(id);
            if (university != null)
            {
                _context.Universities.Remove(university);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(int id)
        {
            return (_context.Universities?.Any(e => e.UniversityId == id)).GetValueOrDefault();
        }
    }
}

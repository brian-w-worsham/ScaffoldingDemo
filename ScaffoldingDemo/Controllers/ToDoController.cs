using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScaffoldingDemo;
using ScaffoldingDemo.Models;

namespace ScaffoldingDemo.Controllers
{
    [ResponseHeader("filter-on-controller", "filter value on controller")]
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: ToDo
        [ResponseHeader("filter-header", "filter value")]
        public async Task<IActionResult> Index()
        {
              return _context.ToDoListModel != null ? 
                          View(await _context.ToDoListModel.ToListAsync()) :
                          Problem("Entity set 'ToDoDbContext.ToDoListModel'  is null.");
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoListModel == null)
            {
                return NotFound();
            }

            var toDoListModel = await _context.ToDoListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoListModel == null)
            {
                return NotFound();
            }

            return View(toDoListModel);
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Note")] ToDoListModel toDoListModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoListModel);
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDoListModel == null)
            {
                return NotFound();
            }

            var toDoListModel = await _context.ToDoListModel.FindAsync(id);
            if (toDoListModel == null)
            {
                return NotFound();
            }
            return View(toDoListModel);
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Note")] ToDoListModel toDoListModel)
        {
            if (id != toDoListModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListModelExists(toDoListModel.Id))
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
            return View(toDoListModel);
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDoListModel == null)
            {
                return NotFound();
            }

            var toDoListModel = await _context.ToDoListModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoListModel == null)
            {
                return NotFound();
            }

            return View(toDoListModel);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDoListModel == null)
            {
                return Problem("Entity set 'ToDoDbContext.ToDoListModel'  is null.");
            }
            var toDoListModel = await _context.ToDoListModel.FindAsync(id);
            if (toDoListModel != null)
            {
                _context.ToDoListModel.Remove(toDoListModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListModelExists(int id)
        {
          return (_context.ToDoListModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

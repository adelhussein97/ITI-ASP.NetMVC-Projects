using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListProjectMVC.Models;
using ToDoListProjectMVC.Models.AppContext;

namespace ToDoListProjectMVC.Controllers
{
    public class TaskCategoriesController : Controller
    {
        private readonly ToDoListContext _context;

        public TaskCategoriesController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: TaskCategories
        public async Task<IActionResult> Index()
        {
              return _context.TasksCategories != null ? 
                          View(await _context.TasksCategories.ToListAsync()) :
                          Problem("Entity set 'ToDoListContext.TasksCategories'  is null.");
        }

        // GET: TaskCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TasksCategories == null)
            {
                return NotFound();
            }

            var taskCategory = await _context.TasksCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskCategory == null)
            {
                return NotFound();
            }

            return View(taskCategory);
        }

        // GET: TaskCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskCategories/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category")] TaskCategory taskCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskCategory);
        }

        // GET: TaskCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TasksCategories == null)
            {
                return NotFound();
            }

            var taskCategory = await _context.TasksCategories.FindAsync(id);
            if (taskCategory == null)
            {
                return NotFound();
            }
            return View(taskCategory);
        }

        // POST: TaskCategories/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category")] TaskCategory taskCategory)
        {
            if (id != taskCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskCategoryExists(taskCategory.Id))
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
            return View(taskCategory);
        }

        // GET: TaskCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TasksCategories == null)
            {
                return NotFound();
            }

            var taskCategory = await _context.TasksCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskCategory == null)
            {
                return NotFound();
            }

            return View(taskCategory);
        }

        // POST: TaskCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TasksCategories == null)
            {
                return Problem("Entity set 'ToDoListContext.TasksCategories'  is null.");
            }
            var taskCategory = await _context.TasksCategories.FindAsync(id);
            if (taskCategory != null)
            {
                _context.TasksCategories.Remove(taskCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskCategoryExists(int id)
        {
          return (_context.TasksCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

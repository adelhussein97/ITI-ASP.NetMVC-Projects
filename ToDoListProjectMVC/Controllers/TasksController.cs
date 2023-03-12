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
    public class TasksController : Controller
    {
        private readonly ToDoListContext _context;

        public TasksController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index(string ? Filter=null,string ? Status=null)
        {
          
           var task = _context.Tasks
                    .Where(c => Filter == null || c.Name.ToLower().Contains(Filter.ToLower()) 
                    || c.User.Name.ToLower().Contains(Filter.ToLower()))
                    .Where(c => Status == null ||
                    (c.Status ==Status)).Include(t => t.Category).Include(t => t.User);

                
            return View(await task.ToListAsync());

        }



        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tasks == null)
            {
                return NotFound();
            }
            var _statusList = from Tasks.StatusList d in Enum.GetValues(typeof(Tasks.StatusList))
                              select new { Id = (int)d, Name = d.ToString() };
            ViewBag.Status = new SelectList(_statusList, "Id", "Name");
            return View(tasks);
        }
        
        // GET: Tasks/Create
        public IActionResult Create()
        {

            var _statusList = from Tasks.StatusList d in Enum.GetValues(typeof(Tasks.StatusList))
                             select new { Id = (int)d, Name = d.ToString() };

            ViewData["CategoryId"] = new SelectList(_context.TasksCategories, "Id", "Category");
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Name");
            ViewBag.Status = new SelectList(_statusList, "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,AssignDate,OwnerId,CategoryId,Description")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var _statusList = from Tasks.StatusList d in Enum.GetValues(typeof(Tasks.StatusList))
                              select new { Id = (int)d, Name = d.ToString() };
            ViewData["CategoryId"] = new SelectList(_context.TasksCategories, "Id", "Category", tasks.CategoryId);
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Name", tasks.OwnerId);
            ViewBag.Status = new SelectList(_statusList, "Id", "Name");
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TasksCategories, "Id", "Category", tasks.CategoryId);
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Name", tasks.OwnerId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,AssignDate,OwnerId,CategoryId,Description")] Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.TasksCategories, "Id", "Category", tasks.CategoryId);
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Name", tasks.OwnerId);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.Category)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'ToDoListContext.Tasks'  is null.");
            }
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks != null)
            {
                _context.Tasks.Remove(tasks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int id)
        {
          return (_context.Tasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

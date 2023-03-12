using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.AppContext;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext context;

        public AuthorController(LibraryContext context)
        {
            this.context = context;
        }

        // GET: AuthorController
        public async Task<IActionResult> Index()
        {
            return context.Authors != null ?
                   View(await context.Authors.ToListAsync()) : Problem("Author Data is Null");


        }
        

        // GET: AuthorController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Authors == null)
                return NotFound();
            var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return  author==null ? NotFound() : View(author);

                
        }

        // GET: AuthorController/Create
        public IActionResult Create()
        {
            return  View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            
                context.Authors.Add(author);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: AuthorController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Authors == null)
                return NotFound();
            var author = await context.Authors.FindAsync(id);
            return author == null ? NotFound() :
                  View(author);

        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,[Bind("Id,Name,Image")] Author author)
        {
            if (id != author.Id)
                return NotFound();
            
                context.Authors.Update(author);
                await context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
           
           

        }

        // GET: AuthorController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Authors==null)
                return NotFound();
            var author =await context.Authors.FirstOrDefaultAsync(a => a.Id == id);
           return author == null ? NotFound() : View(author);


        }

        // POST: AuthorController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAuthor(int? id)
        {
            if (context.Authors == null)
                return Problem("Entity Author Is Null");
            var author = await context.Authors.FindAsync(id);
            if (author != null)
                context.Authors.Remove(author);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

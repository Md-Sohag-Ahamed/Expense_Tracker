using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

    // GET: Categories
    public async Task<IActionResult> Index()
    {
      return _context.Categories != null ?
                  View(await _context.Categories.ToListAsync()) :
                  Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
    }
  
        //// GET: Categories/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}


    // GET: Categories/AddOrEdit
    [HttpGet]
    public IActionResult AddOrEdit(int id = 0)
    {
      if (id == 0)
        return View(new Category());
      else
        return View(_context.Categories.Find(id));

    }

    // POST: Categories/AddOrEdit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> AddOrEdit([Bind("CategoryId,CategoryName,Type")] Category category)
    {
      if (ModelState.IsValid)
      {
        if (!CategoryExists(category.CategoryName))
        {
          try
          {
            if (category.CategoryId == 0)
              _context.Add(category);
            else
              _context.Update(category);

          }
          catch (DbUpdateConcurrencyException)
          {
           

          }
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));


        }
        else
        {
          ViewBag.Message = "This Category Already Exit";
          
        }

       
      }
      return View(category);
    }

    //public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Type")] Category category)
    //    {
    //        if (id != category.CategoryId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(category);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!CategoryExists(category.CategoryId))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(category);
    //    }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(string name)
        {
            return _context.Categories.Any(e => e.CategoryName == name);
        }
    }
}

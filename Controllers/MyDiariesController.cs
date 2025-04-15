using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineDiary.Areas.Identity.Data;
using OnlineDiary.Data;
using OnlineDiary.Models;

namespace OnlineDiary.Controllers
{
    [Authorize]
    public class MyDiariesController : Controller
    {
        private readonly OnlineDiaryContext _context;
        private readonly UserManager<OnlineDiaryUser> _userManager;

        public MyDiariesController(OnlineDiaryContext context, UserManager<OnlineDiaryUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MyDiaries
        public async Task<IActionResult> Index()
        {
            var model = await _context.MyDiaries
                            .Where(a => a.User.Id == _userManager.GetUserId(User))
                            .ToListAsync();
            return View(model);
        }

        // GET: MyDiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var myDiary = await _context.MyDiaries
                .FirstOrDefaultAsync(m => m.MyDiaryId == id && m.User.Id == _userManager.GetUserId(User));
            if (myDiary == null)
                return NotFound();

            return View(myDiary);
        }

        // GET: MyDiaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyDiaries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyDiaryId,Title,Date,Entry")] MyDiary myDiary)
        {
            if (ModelState.IsValid)
            {
                myDiary.User = await _userManager.GetUserAsync(User);
                _context.Add(myDiary);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Diary entry created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(myDiary);
        }

        // GET: MyDiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var myDiary = await _context.MyDiaries
                .FirstOrDefaultAsync(m => m.MyDiaryId == id && m.User.Id == _userManager.GetUserId(User));
            if (myDiary == null)
                return NotFound();

            return View(myDiary);
        }

        // POST: MyDiaries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyDiaryId,Title,Date,Entry")] MyDiary myDiary)
        {
            if (id != myDiary.MyDiaryId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingDiary = await _context.MyDiaries
                        .FirstOrDefaultAsync(m => m.MyDiaryId == id && m.User.Id == _userManager.GetUserId(User));
                    if (existingDiary == null)
                        return NotFound();

                    existingDiary.Title = myDiary.Title;
                    existingDiary.Date = myDiary.Date;
                    existingDiary.Entry = myDiary.Entry;

                    _context.Update(existingDiary);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Diary entry updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyDiaryExists(myDiary.MyDiaryId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(myDiary);
        }

        // GET: MyDiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var myDiary = await _context.MyDiaries
                .FirstOrDefaultAsync(m => m.MyDiaryId == id && m.User.Id == _userManager.GetUserId(User));
            if (myDiary == null)
                return NotFound();

            return View(myDiary);
        }

        // POST: MyDiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myDiary = await _context.MyDiaries
                .FirstOrDefaultAsync(m => m.MyDiaryId == id && m.User.Id == _userManager.GetUserId(User));
            if (myDiary != null)
            {
                _context.MyDiaries.Remove(myDiary);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Diary entry deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MyDiaryExists(int id)
        {
            return (_context.MyDiaries?.Any(e => e.MyDiaryId == id)).GetValueOrDefault();
        }
    }
}

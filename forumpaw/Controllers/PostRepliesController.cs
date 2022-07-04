﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using forumpaw.Models;

namespace forumpaw.Controllers
{
    public class PostRepliesController : Controller
    {
        private readonly ForumContext _context;

        public PostRepliesController(ForumContext context)
        {
            _context = context;
        }

        // GET: PostReplies
        public async Task<IActionResult> Index()
        {
              return _context.PostReply != null ? 
                          View(await _context.PostReply.ToListAsync()) :
                          Problem("Entity set 'ForumContext.PostReply'  is null.");
        }

        // GET: PostReplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostReply == null)
            {
                return NotFound();
            }

            var postReply = await _context.PostReply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postReply == null)
            {
                return NotFound();
            }

            return View(postReply);
        }

        // GET: PostReplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostReplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Created")] PostReply postReply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postReply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postReply);
        }

        // GET: PostReplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostReply == null)
            {
                return NotFound();
            }

            var postReply = await _context.PostReply.FindAsync(id);
            if (postReply == null)
            {
                return NotFound();
            }
            return View(postReply);
        }

        // POST: PostReplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Created")] PostReply postReply)
        {
            if (id != postReply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postReply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostReplyExists(postReply.Id))
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
            return View(postReply);
        }

        // GET: PostReplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostReply == null)
            {
                return NotFound();
            }

            var postReply = await _context.PostReply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postReply == null)
            {
                return NotFound();
            }

            return View(postReply);
        }

        // POST: PostReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostReply == null)
            {
                return Problem("Entity set 'ForumContext.PostReply'  is null.");
            }
            var postReply = await _context.PostReply.FindAsync(id);
            if (postReply != null)
            {
                _context.PostReply.Remove(postReply);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostReplyExists(int id)
        {
          return (_context.PostReply?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

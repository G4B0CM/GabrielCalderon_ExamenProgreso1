using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GabrielCalderon_ExamenProgreso1.Data;
using GabrielCalderon_ExamenProgreso1.Models;

namespace GabrielCalderon_ExamenProgreso1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly GabrielCalderon_ExamenProgreso1Context _context;

        public UsuariosController(GabrielCalderon_ExamenProgreso1Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var gabrielCalderon_ExamenProgreso1Context = _context.GCalderon.Include(g => g.Celular);
            return View(await gabrielCalderon_ExamenProgreso1Context.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gCalderon = await _context.GCalderon
                .Include(g => g.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gCalderon == null)
            {
                return NotFound();
            }

            return View(gCalderon);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,Contrasena,numtelf,Saldo,FechaNacimiento,EsCliente,CelularId")] GCalderon gCalderon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gCalderon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", gCalderon.CelularId);
            return View(gCalderon);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gCalderon = await _context.GCalderon.FindAsync(id);
            if (gCalderon == null)
            {
                return NotFound();
            }
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", gCalderon.CelularId);
            return View(gCalderon);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Contrasena,numtelf,Saldo,FechaNacimiento,EsCliente,CelularId")] GCalderon gCalderon)
        {
            if (id != gCalderon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gCalderon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GCalderonExists(gCalderon.Id))
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
            ViewData["CelularId"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", gCalderon.CelularId);
            return View(gCalderon);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gCalderon = await _context.GCalderon
                .Include(g => g.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gCalderon == null)
            {
                return NotFound();
            }

            return View(gCalderon);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gCalderon = await _context.GCalderon.FindAsync(id);
            if (gCalderon != null)
            {
                _context.GCalderon.Remove(gCalderon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GCalderonExists(int id)
        {
            return _context.GCalderon.Any(e => e.Id == id);
        }
    }
}

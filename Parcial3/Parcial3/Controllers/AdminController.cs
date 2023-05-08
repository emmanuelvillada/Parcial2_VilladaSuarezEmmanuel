using System.Data.Entity;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial3.Dal;
using Parcial3.Dal.Entities;
using Parcial3.Helpers;

namespace Parcial3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DatabaseContext _context;
        private readonly IDropDownListsHelper _ddlHelper;
        

        public AdminController(IUserHelper userHelper, DatabaseContext context, IDropDownListsHelper dropDownListsHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _ddlHelper = dropDownListsHelper;
            
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return _context.Services != null ?
                        View(await _context.Services.ToListAsync()) :
                        Problem("Entity set 'DatabaseContext.Services'  is null.");
        }


       

        // GET Edit
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }

        // POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(service.Id))
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
            return View(service);
        }

       

        private bool ServicesExists(Guid id)
        {
            return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}

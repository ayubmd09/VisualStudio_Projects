using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarInsurance.Models;
using CarInsurance.Data;

public class InsureesController : Controller
{
    private readonly CarInsuranceContext _context;

    public InsureesController(CarInsuranceContext context)
    {
        _context = context;
    }

    // GET: INSUREES
    public async Task<IActionResult> Index()
    {
        return View(await _context.Insurees.ToListAsync());
    }

    // GET: INSUREES/Admin
    public async Task<IActionResult> Admin()
    {
        return View(await _context.Insurees.ToListAsync());
    }

    // GET: INSUREES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);

        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // GET: INSUREES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: INSUREES/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            // Start with the base monthly quote
            decimal quote = 50m;

            // Calculate the user's age
            var today = DateTime.Today;
            int age = today.Year - insuree.DateOfBirth.Year;

            if (insuree.DateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            // Age adjustment
            if (age <= 18)
            {
                quote += 100m;
            }
            else if (age <= 25)
            {
                quote += 50m;
            }
            else
            {
                quote += 25m;
            }

            // Car year adjustment
            if (insuree.CarYear < 2000)
            {
                quote += 25m;
            }

            if (insuree.CarYear > 2015)
            {
                quote += 25m;
            }

            // Porsche adjustment
            if (insuree.CarMake.Equals(
                "Porsche",
                StringComparison.OrdinalIgnoreCase))
            {
                quote += 25m;

                // Additional $25 for Porsche 911 Carrera
                if (insuree.CarModel.Equals(
                    "911 Carrera",
                    StringComparison.OrdinalIgnoreCase))
                {
                    quote += 25m;
                }
            }

            // $10 for each speeding ticket
            quote += insuree.SpeedingTickets * 10m;

            // DUI adds 25%
            if (insuree.DUI)
            {
                quote *= 1.25m;
            }

            // Full coverage adds 50%
            if (insuree.CoverageType.Equals(
                "Full",
                StringComparison.OrdinalIgnoreCase))
            {
                quote *= 1.50m;
            }

            // Store the calculated quote
            insuree.Quote = quote;

            _context.Add(insuree);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(insuree);
    }

    // GET: INSUREES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees.FindAsync(id);

        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // POST: INSUREES/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
    {
        if (id != insuree.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(insuree);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsureeExists(insuree.Id))
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

        return View(insuree);
    }

    // GET: INSUREES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);

        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // POST: INSUREES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var insuree = await _context.Insurees.FindAsync(id);

        if (insuree != null)
        {
            _context.Insurees.Remove(insuree);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool InsureeExists(int? id)
    {
        return _context.Insurees.Any(e => e.Id == id);
    }
}
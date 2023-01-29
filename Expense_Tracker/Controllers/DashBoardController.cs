using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker.Controllers
{
  public class DashBoardController : Controller
  {
    private readonly ApplicationDbContext _context;

    public DashBoardController(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Index()
    {
      DateTime StartDate = DateTime.Today;
      DateTime EndDate = DateTime.Today;
      List<Transaction> SelectedTransactions = await _context.Transactions
        .Include(x => x.Category)
        .Where(s=>s.ExpenseDate>=StartDate && s.ExpenseDate<= EndDate)
        .ToListAsync();

      int TotalExpense = SelectedTransactions
          //.Where(i => i.Category.Type == "Expense")
          .Sum(j => j.Amount);
      ViewBag.TotalExpense = TotalExpense.ToString("C0");

      return View();
    }
  }
}

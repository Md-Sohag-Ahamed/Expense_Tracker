using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker.Models
{
  public class Transaction
  {
    [Key]
    public int TransactionId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
    public int Amount { get; set; }

    public DateTime ExpenseDate { get; set; } = DateTime.Now;
    //public DateTime ToDate { get; set; } = DateTime.Now;
  }
}

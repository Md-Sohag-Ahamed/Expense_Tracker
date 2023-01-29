using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker.Models
{
  public class Category
  {
    [Key]
    public int CategoryId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [Required(ErrorMessage = "Title is required.")]
    public string CategoryName { get; set; }
    [Column(TypeName = "nvarchar(10)")]
    public string Type { get; set; } = "Expense";

  }
  
}

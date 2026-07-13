using System;
using System.Collections.Generic;
using System.Text;

// Id, Title, Amount, Date, Category

namespace LifeManager.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
